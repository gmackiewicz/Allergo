using System;
using System.Collections.Generic;
using System.Linq;
using Allergo.Common.Exceptions;
using Allergo.Data.Contracts;
using Allergo.Data.Models.Account;
using Allergo.Schedule.Contracts;
using Allergo.Schedule.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Allergo.Common.Dto;
using Allergo.Data.Models.Schedule;
using AutoMapper;

namespace Allergo.Schedule.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly IDataService _dataService;

        public ScheduleService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ScheduleDto> GetSchedule(GetScheduleRequestDto request)
        {
            var doctor = await _dataService
                .GetSet<AllergoUser>()
                .Include(x => x.AdmissionHours)
                .FirstOrDefaultAsync(x => x.Id.ToString() == request.DoctorId);

            if (doctor == null)
            {
                throw new InvalidDoctorIdException($"Could not find doctor with id: {request.DoctorId}");
            }
            
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

        public Task CreateSchedule(CreateScheduleRequestDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveSchedule(RemoveScheduleRequestDto request)
        {
            throw new System.NotImplementedException();
        }
    }
}
