using System;
using System.Collections.Generic;
using Allergo.Web.ViewModels.Appointment;

namespace Allergo.Web.ViewModels.Schedule
{
    public class DayScheduleViewModel
    {
        public string Id { get; set; }
        public DateTime Day { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}