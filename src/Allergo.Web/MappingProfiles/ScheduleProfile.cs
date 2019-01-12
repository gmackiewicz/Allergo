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
            CreateMap<CreateScheduleRequestViewModel, CreateScheduleRequestDto>().ReverseMap();
            CreateMap<DayScheduleDto, DayScheduleViewModel>().ReverseMap();
            CreateMap<ScheduleDto, ScheduleViewModel>().ReverseMap();
            CreateMap<AdmissionHours, DayScheduleDto>().ReverseMap();
            CreateMap<DayScheduleTermViewModel, DayScheduleTermDto>().ReverseMap();
        }
    }
}
