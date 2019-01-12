using System;
using Allergo.Data.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace Allergo.Data
{
    public class AllergoDbInitializer
    {
        public static void SeedUsers(UserManager<AllergoUser> userManager)
        {
            var adminUser = new AllergoUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.pl",
                NormalizedEmail = "ADMIN@ADMIN.pl",
                FirstName = "Admin",
                LastName = "Adminowski",
            };

            var doctorUser = new AllergoUser
            {
                UserName = "doctor",
                NormalizedUserName = "DOCTOR",
                Email = "doktor@doktor.pl",
                NormalizedEmail = "DOKTOR@DOKTOR.pl",
                FirstName = "Doktor",
                LastName = "Doktorski",
            };

            var patientUser = new AllergoUser
            {
                UserName = "patient",
                NormalizedUserName = "PATIENT",
                Email = "patient@patient.pl",
                NormalizedEmail = "PATIENT@PATIENT.pl",
                FirstName = "Pacjent",
                LastName = "Cierpliwy",
            };

            AddIfNotExists(adminUser, userManager);
            AddIfNotExists(doctorUser, userManager);
            AddIfNotExists(patientUser, userManager);
        }

        private static void AddIfNotExists(AllergoUser user, UserManager<AllergoUser> userManager)
        {
            if (userManager.FindByNameAsync(user.UserName).Result == null)
            {             
                IdentityResult result = userManager.CreateAsync(user, "Haslo123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, user.UserName.ToUpper()).Wait();
                }
            }
        }
    }
}
