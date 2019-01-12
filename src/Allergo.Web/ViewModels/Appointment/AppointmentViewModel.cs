﻿namespace Allergo.Web.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public bool IsCurrentUser { get; set; }
        public bool IsTaken { get; set; }
        public bool IsTakenByCurrentUser { get; set; }
    }
}
