﻿using Allergo.Data.Models.Account;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Allergo.Appointment.Dto
{
    public class AppointmentDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public AllergoUser User { get; set; }
        public AllergoUser Doctor { get; set; }
        public bool IsCancelled { get; set; }
        public string Diagnosis { get; set; }

        [NotMapped]
        public bool IsPast => Date <= DateTime.UtcNow;
    }
}
