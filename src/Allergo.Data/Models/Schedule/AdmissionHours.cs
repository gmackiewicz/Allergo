using System;
using Allergo.Data.Models.Account;

namespace Allergo.Data.Models.Schedule
{
    public class AdmissionHours
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsCurrent { get; set; }
        public virtual AllergoUser Doctor { get; set; }
    }
}
