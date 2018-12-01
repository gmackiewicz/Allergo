using System;

namespace Allergo.Schedule.Dto
{
    public class DayScheduleDto
    {
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
