using Allergo.Data.Models.Schedule;
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

            CreateMap<DayScheduleDto, DayScheduleViewModel>();
            CreateMap<ScheduleDto, ScheduleViewModel>();

            CreateMap<AdmissionHours, DayScheduleDto>();
        }
    }
}
