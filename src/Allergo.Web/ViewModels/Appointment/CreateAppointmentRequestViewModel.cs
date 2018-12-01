using System;

namespace Allergo.Web.ViewModels.Appointment
{
    public class CreateAppointmentRequestViewModel
    {
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string DoctorId { get; set; }
    }
}
