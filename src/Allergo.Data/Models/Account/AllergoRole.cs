using System;
using Microsoft.AspNetCore.Identity;

namespace Allergo.Data.Models.Account
{
    public class AllergoRole : IdentityRole<Guid>
    {
        public static implicit operator IdentityRole<string>(AllergoRole input)
        {
            return new IdentityRole<string>
            {
                ConcurrencyStamp = input.ConcurrencyStamp,
                Id = input.Id.ToString(),
                Name = input.Name,
                NormalizedName = input.NormalizedName
            };
        }

        public static implicit operator AllergoRole(IdentityRole<string> input)
        {
            return new AllergoRole
            {
                ConcurrencyStamp = input.ConcurrencyStamp,
                Id = new Guid(input.Id),
                Name = input.Name,
                NormalizedName = input.NormalizedName
            };
        }
    }
}
