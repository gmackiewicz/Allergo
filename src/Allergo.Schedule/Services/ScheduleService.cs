using Allergo.Common.Contracts;
using Allergo.Common.Dto;
using Allergo.Common.Exceptions;
using Allergo.Data.Contracts;
using Allergo.Data.Models.Account;
using Allergo.Data.Models.Schedule;
using Allergo.Schedule.Contracts;
using Allergo.Schedule.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Allergo.Schedule.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly IDataService _dataService;
        private readonly IDoctorService _doctorService;

        public ScheduleService(
            IDataService dataService,
            IDoctorService doctorService)
        {
            _dataService = dataService;
            _doctorService = doctorService;
        }

        public async Task<ScheduleDto> GetScheduleAsync(GetScheduleRequestDto request)
        {
            var doctor = await _doctorService.GetDoctorAsync(request.DoctorId);           
            var result = new ScheduleDto();

            result.Doctor = Mapper.Map<AllergoUser, DoctorDto>(doctor);

            for (int i = 0; i < 7; i++)
            {
                var day = request.DayFrom.AddDays(i);
                var doctorDaySchedule =
                    doctor.AdmissionHours.FirstOrDefault(x => x.IsCurrent && x.DayOfWeek == day.DayOfWeek);

                if (doctorDaySchedule != null)
                {
                    var dayScheduleDto = Mapper.Map<AdmissionHours, DayScheduleDto>(doctorDaySchedule);
                    dayScheduleDto.Day = day;
                    result.DaySchedules.Add(dayScheduleDto);
                }
            }

            return result;
        }

        public async Task CreateScheduleAsync(CreateScheduleRequestDto request)
        {
            var doctor = await _doctorService.GetDoctorAsync(request.DoctorId.ToString());

            var collidingSchedule = doctor.AdmissionHours
                .FirstOrDefault(x =>
                    x.IsCurrent && x.DayOfWeek == request.DayOfWeek
                                && (request.StartTime >= x.StartTime && request.StartTime < x.EndTime ||
                                    request.StartTime <= x.StartTime && request.EndTime > x.StartTime));

            if (collidingSchedule != null)
            {
                throw new CollidingScheduleException(
                    $"Cannot create a schedule for time: {request.StartTime} {request.EndTime} and day: {request.DayOfWeek}");
            }

            var newAdmissionHours = new AdmissionHours
            {
                DayOfWeek = request.DayOfWeek,
                Doctor = doctor,
                EndTime = request.EndTime,
                StartTime = request.StartTime,
                IsCurrent = true
            };

            await _dataService.GetSet<AdmissionHours>().AddAsync(newAdmissionHours);
            await _dataService.SaveDbAsync();
        }

        public async Task RemoveScheduleAsync(RemoveScheduleRequestDto request)
        {
            var existingSchedule = await _dataService.GetSet<AdmissionHours>()
                .FirstOrDefaultAsync(x => x.Id.ToString() == request.ScheduleId && x.IsCurrent);

            if (existingSchedule == null)
            {
                throw new InvalidScheduleIdException($"Couldn't find active schedule with id: {request.ScheduleId}");
            }

            existingSchedule.IsCurrent = false;
            await _dataService.SaveDbAsync();
        }
    }
}
