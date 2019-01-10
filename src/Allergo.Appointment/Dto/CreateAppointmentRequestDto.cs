using System;

namespace Allergo.Appointment.Dto
{
    public class CreateAppointmentRequestDto
    {
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public string DoctorId { get; set; }
    }
}
