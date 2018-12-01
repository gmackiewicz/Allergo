using Allergo.Schedule.Dto;
using Allergo.Web.ViewModels.Schedule;
using AutoMapper;

namespace Allergo.Web.MappingProfiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<CreateScheduleRequestViewModel, CreateScheduleRequestDto>();
            CreateMap<GetScheduleRequestViewModel, GetScheduleRequestDto>();
            CreateMap<RemoveScheduleRequestViewModel, RemoveScheduleRequestDto>();

            CreateMap<DayScheduleDto, DayScheduleViewModel>();
            CreateMap<ScheduleDto, ScheduleViewModel>();
        }
    }
}
