using Allergo.Data.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;

namespace Allergo.Data
{
    public class AllergoDbContext : IdentityDbContext<AllergoUser, AllergoRole, Guid>
    {
        public AllergoDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
