using Allergo.Home.Models;
using Allergo.Web.ViewModels.Home;
using AutoMapper;

namespace Allergo.Web.MappingProfiles
{
    public class HomeProfile: Profile
    {
        public HomeProfile()
        {
            CreateMap<AllergoStatisticsDto, AllergoStatisticsViewModel>().ReverseMap();
        }
    }
}
