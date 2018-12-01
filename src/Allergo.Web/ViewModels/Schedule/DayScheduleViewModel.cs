using System;
using System.Collections.Generic;
using Allergo.Web.ViewModels.Appoinment;

namespace Allergo.Web.ViewModels.Schedule
{
    public class DayScheduleViewModel
    {
        public DateTime Day { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}