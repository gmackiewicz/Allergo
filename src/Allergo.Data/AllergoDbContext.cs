using Allergo.Data.Models.Account;
using Allergo.Data.Models.Appointment;
using Allergo.Data.Models.Schedule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

            InitializeAllergoRoles(builder);

            base.OnModelCreating(builder);
        }

        private void InitializeAllergoRoles(ModelBuilder builder)
        {
            builder.Entity<AllergoRole>().HasData(new AllergoRole
            {
                Id = new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"),
                Name = "Doctor",
                NormalizedName = "DOCTOR",
                ConcurrencyStamp = "3ca04c41-6ba2-41b4-8549-98e09c83777f"
            });

            builder.Entity<AllergoRole>().HasData(new AllergoRole
            {
                Id = new Guid("5ec55e49-85fa-407c-a308-4faaec25ded0"),
                Name = "Patient",
                NormalizedName = "PATIENT",
                ConcurrencyStamp = "5ec55e49-85fa-407c-a308-4faaec25ded0"
            });

            builder.Entity<AllergoRole>().HasData(new AllergoRole
            {
                Id = new Guid("275b3afd-e537-4e98-9d67-622b37606565"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "275b3afd-e537-4e98-9d67-622b37606565"
            });
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
