using Allergo.Data.Models.Account;
using System.Threading.Tasks;

namespace Allergo.Common.Contracts
{
    public interface IDoctorService
    {
        Task<AllergoUser> GetDoctorAsync(string doctorId);
    }
}
