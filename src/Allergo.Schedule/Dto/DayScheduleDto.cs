using System;
using System.Collections.Generic;

namespace Allergo.Schedule.Dto
{
    public class DayScheduleDto
    {
        public string Id { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<DayScheduleTermDto> Terms { get; set; }
    }
}
