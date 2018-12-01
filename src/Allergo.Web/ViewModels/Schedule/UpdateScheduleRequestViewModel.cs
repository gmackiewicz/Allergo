using System;

namespace Allergo.Web.ViewModels.Schedule
{
    public class CreateScheduleRequestViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
