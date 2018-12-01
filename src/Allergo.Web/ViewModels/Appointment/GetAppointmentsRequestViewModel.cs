using System;

namespace Allergo.Web.ViewModels.Appointment
{
    public class GetAppointmentsRequestViewModel
    {
        public DateTime FromDay { get; set; }
        public DateTime ToDay { get; set; }
    }
}
