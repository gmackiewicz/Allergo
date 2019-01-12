using Allergo.Appointment.Contracts;
using Allergo.Appointment.Dto;
using Allergo.Common.Contracts;
using Allergo.Common.Exceptions;
using Allergo.Data.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergo.Appointment.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDataService _dataService;
        private readonly IDoctorService _doctorService;

        public AppointmentService(
            IDataService dataService,
            IDoctorService doctorService)
        {
            _dataService = dataService;
            _doctorService = doctorService;
        }

        public async Task CreateAppointmentAsync(CreateAppointmentRequestDto request)
        {
            var doctor = await _doctorService.GetDoctorAsync(request.DoctorId);

            if (doctor == null)
            {
                throw new InvalidDoctorIdException();
            }

            var appointmentSet = _dataService.GetSet<Data.Models.Appointment.Appointment>();


            var collidingAppointment = await appointmentSet
                .FirstOrDefaultAsync(x =>
                    !x.IsCancelled &&
                    x.Date.Day == request.Date.Day && x.Date.Hour == request.Date.Hour &&
                    x.Date.Minute == request.Date.Minute);

            if (collidingAppointment != null)
            {
                throw new CollidingAppointmentException(
                    $"Cannot create an appointment for time: {request.Date} as it's already taken!");
            }

            var newAppointment = new Data.Models.Appointment.Appointment
            {
                Doctor = doctor,
                Date = request.Date,
                UserId = request.UserId
            };

            await appointmentSet.AddAsync(newAppointment);
            await _dataService.SaveDbAsync();
        }

        public IList<AppointmentDto> GetUserAppointments(Guid userId, DateTime? beforeDate)
        {
            var result =
                _dataService
                    .GetSet<Data.Models.Appointment.Appointment>()
                    .Where(a =>
                        a.UserId == userId &&
                        beforeDate.HasValue ? a.Date <= beforeDate : true)
                    .Include(x => x.Doctor)
                    .Select(a => Mapper.Map<AppointmentDto>(a))
                    .ToList();

            return result;
        }

        public IList<AppointmentDto> GetDoctorAppointments(Guid doctorId, DateTime? beforeDate)
        {
            var result =
                _dataService
                    .GetSet<Data.Models.Appointment.Appointment>()
                    .Where(a =>
                        a.DoctorId == doctorId &&
                        beforeDate.HasValue ? a.Date <= beforeDate : true)
                    .Include(x => x.User)
                    .Select(a => Mapper.Map<AppointmentDto>(a))
                    .ToList();

            return result;
        }

        public async Task UpdateAppointmentAsync(AppointmentDto appointmentDto)
        {
            var set = _dataService.GetSet<Data.Models.Appointment.Appointment>();

            var appointment = await set.FirstOrDefaultAsync(x => appointmentDto.Id == x.Id.ToString());

            if (appointment == null)
            {
                throw new InvalidAppointmentIdException();
            }

            appointment.Diagnosis = appointmentDto.Diagnosis;

            set.Update(appointment);

            await _dataService.SaveDbAsync();
        }

        public async Task<AppointmentDto> GetAppointmentById(string id)
        {
            var appointment = await _dataService.GetSet<Data.Models.Appointment.Appointment>().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (appointment == null)
            {
                throw new InvalidAppointmentIdException();
            }

            var appointmentDto = Mapper.Map<AppointmentDto>(appointment);

            return appointmentDto;
        }

        public async Task CancelAppointment(CancelAppointmentRequestDto model)
        {
            var set = _dataService.GetSet<Data.Models.Appointment.Appointment>();

            var appointment = await set.FirstOrDefaultAsync(x => x.Id.ToString() == model.AppointmentId);

            if (appointment == null)
            {
                throw new InvalidAppointmentIdException();
            }

            if (appointment.UserId.ToString() != model.UserId)
            {
                throw new BadRequestException("User cannot cancel not his own appointment!");
            }

            appointment.IsCancelled = true;
            set.Update(appointment);

            await _dataService.SaveDbAsync();
        }
    }
}
