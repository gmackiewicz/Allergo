using System;
using System.Collections.Generic;

namespace Allergo.Web.ViewModels.Schedule
{
    public class DayScheduleViewModel
    {
        public string Id { get; set; }
        public DateTime Day { get; set; }
        public List<DayScheduleTermViewModel> Terms { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}