using Allergo.Data.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Allergo.Data.Models.Appointment;
using Allergo.Data.Models.Schedule;
using Microsoft.EntityFrameworkCore;

namespace Allergo.Data
{
    public class AllergoDbContext : IdentityDbContext<AllergoUser, AllergoRole, Guid>
    {
        public DbSet<AdmissionHours> AdmissionHours { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public AllergoDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
