using Allergo.Common.Dto;
using System.Collections.Generic;

namespace Allergo.Schedule.Dto
{
    public class ScheduleDto
    {
        public DoctorDto Doctor { get; set; }
        public List<DayScheduleDto> DaySchedules { get; set; }

        public ScheduleDto()
        {
            DaySchedules = new List<DayScheduleDto>();
        }
    }
}
