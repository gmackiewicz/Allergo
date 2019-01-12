using System;

namespace Allergo.Appointment.Dto
{
    public class GetAppointmentsRequestDto
    {
        public DateTime FromDay { get; set; }
        public DateTime ToDay { get; set; }
    }
}
