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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureAppointmentModel(builder);

            ConfigureAdmissionHoursModel(builder);

            base.OnModelCreating(builder);
        }

        private void ConfigureAppointmentModel(ModelBuilder builder)
        {
            builder.Entity<Appointment>()
                .HasOne(x => x.Doctor)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureAdmissionHoursModel(ModelBuilder builder)
        {
            builder.Entity<AdmissionHours>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.AdmissionHours)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
