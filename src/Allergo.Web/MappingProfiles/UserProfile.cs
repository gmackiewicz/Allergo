using Allergo.Account.Models;
using Allergo.Data.Models.Account;
using Allergo.Web.ViewModels.User;
using AutoMapper;

namespace Allergo.Web.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<EditUserRequestViewModel, EditUserRequestDto>();
            CreateMap<AllergoUser, UserDto>();
        }
    }
}
