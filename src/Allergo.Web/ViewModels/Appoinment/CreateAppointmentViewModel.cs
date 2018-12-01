using System;

namespace Allergo.Web.ViewModels.Appoinment
{
    public class CreateAppointmentViewModel
    {
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string DoctorId { get; set; }
    }
}
