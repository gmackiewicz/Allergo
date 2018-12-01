using System;

namespace Allergo.Schedule.Dto
{
    public class DayScheduleDto
    {
        public string Id { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
