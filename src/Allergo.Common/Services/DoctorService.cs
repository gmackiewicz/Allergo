using Allergo.Common.Contracts;
using Allergo.Common.Exceptions;
using Allergo.Data.Contracts;
using Allergo.Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Allergo.Common.Services
{
    public class DoctorService: IDoctorService
    {
        private readonly IDataService _dataService;

        public DoctorService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<AllergoUser> GetDoctorAsync(string doctorId)
        {
            var doctor = await _dataService
                .GetSet<AllergoUser>()
                .Include(x => x.AdmissionHours)
                .FirstOrDefaultAsync(x => x.Id.ToString() == doctorId);

            if (doctor == null)
            {
                throw new InvalidDoctorIdException($"Could not find doctor with id: {doctorId}");
            }

            return doctor;
        }
    }
}
