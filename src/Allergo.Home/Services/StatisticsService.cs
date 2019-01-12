using Allergo.Data.Contracts;
using Allergo.Home.Contracts;
using Allergo.Home.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Allergo.Data.Models.Account;
using Allergo.Data.Models.Appointment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Allergo.Home.Services
{
    public class StatisticsService: IStatisticsService
    {
        private readonly IDataService _dataService;

        public StatisticsService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<AllergoStatisticsDto> GetStatisticsAsync()
        {
            var model = new AllergoStatisticsDto();

            model.RegisteredUsersCount = await _dataService.GetSet<AllergoUser>().CountAsync();
            model.AppointmentsCount = await _dataService.GetSet<Appointment>().CountAsync();
            model.DoctorsCount = await _dataService.GetSet<AllergoUser>()
                .Include(x => x.UserRoles)
                .Where(x => x.UserRoles.FirstOrDefault(y =>
                                y.RoleId.ToString() == "3ca04c41-6ba2-41b4-8549-98e09c83777f") != null)
                .CountAsync();

            return model;
        }
    }
}
