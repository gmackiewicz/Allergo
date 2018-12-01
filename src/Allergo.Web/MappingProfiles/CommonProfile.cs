using Allergo.Common.Dto;
using Allergo.Data.Models.Account;
using Allergo.Web.ViewModels.Common;
using AutoMapper;

namespace Allergo.Web.MappingProfiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<DoctorDto, DoctorViewModel>();
            CreateMap<AllergoUser, DoctorDto>();
        }
    }
}
