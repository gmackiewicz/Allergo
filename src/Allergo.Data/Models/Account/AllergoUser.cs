using System;
using System.Collections.Generic;
using Allergo.Data.Models.Schedule;
using Microsoft.AspNetCore.Identity;

namespace Allergo.Data.Models.Account
{
    public class AllergoUser : IdentityUser<Guid>
    {
        public virtual ICollection<AdmissionHours> AdmissionHours { get; set; }
    }
}
