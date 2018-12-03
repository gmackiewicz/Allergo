using Allergo.Common.Dto;
using Allergo.Data.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allergo.Common.Contracts
{
    public interface IDoctorService
    {
        Task<AllergoUser> GetDoctorAsync(string doctorId);
        Task<List<DoctorDto>> GetAllAsync();
    }
}
