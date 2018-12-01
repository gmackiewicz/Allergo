using System;

namespace Allergo.Schedule.Dto
{
    public class CreateScheduleRequestDto
    {
        public string DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
