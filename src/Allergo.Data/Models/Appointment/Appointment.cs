using System;
using Allergo.Data.Models.Account;

namespace Allergo.Data.Models.Appointment
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }
        public bool IsCancelled { get; set; }
        public virtual AllergoUser User { get; set; }
        public virtual AllergoUser Doctor { get; set; }
    }
}
