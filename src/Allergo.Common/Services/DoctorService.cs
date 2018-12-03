using Allergo.Common.Contracts;
using Allergo.Common.Dto;
using Allergo.Common.Enums;
using Allergo.Common.Exceptions;
using Allergo.Data.Contracts;
using Allergo.Data.Models.Account;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergo.Common.Services
{
    public class DoctorService: IDoctorService
    {
        private readonly IDataService _dataService;
        private readonly UserManager<AllergoUser> _userManager;

        public DoctorService(IDataService dataService, UserManager<AllergoUser> userManager)
        {
            _dataService = dataService;
            _userManager = userManager;
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

        public async Task<List<DoctorDto>> GetAllAsync()
        {
            var doctors = await _userManager.GetUsersInRoleAsync(AllergoRoleNames.Doctor);

            return Mapper.Map<List<AllergoUser>, List<DoctorDto>>(doctors.ToList());
        }
    }
}
