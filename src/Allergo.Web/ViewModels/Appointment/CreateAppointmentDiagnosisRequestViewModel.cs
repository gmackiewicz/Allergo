using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergo.Web.ViewModels.Appointment
{
    public class CreateAppointmentDiagnosisRequestViewModel
    {
        public string AppointmentId { get; set; }
        public string Diagnosis { get; set; }
    }
}
