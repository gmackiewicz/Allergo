using System.Threading.Tasks;
using Allergo.Home.Contracts;
using Allergo.Web.ViewModels.Home;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allergo.Web.Controllers
{
    [Authorize]
    public class HomeController: AllergoBaseController
    {
        private readonly IStatisticsService _statisticsService;

        public HomeController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<ActionResult> GetDashboardData()
        {
            var statistics = await _statisticsService.GetStatisticsAsync();

            var result = new DashboardDataViewModel
            {
                Statistics = Mapper.Map<AllergoStatisticsViewModel>(statistics)
            };

            return Json(result);
        }
    }
}
