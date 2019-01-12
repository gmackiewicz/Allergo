using Allergo.Appointment.Dto;
using Allergo.Web.ViewModels.Appointment;
using AutoMapper;

namespace Allergo.Web.MappingProfiles
{
    public class AppointmentProfile: Profile
    {
        public AppointmentProfile()
        {
            CreateMap<CreateAppointmentRequestViewModel, CreateAppointmentRequestDto>().ReverseMap();
            CreateMap<CancelAppointmentRequestViewModel, CancelAppointmentRequestDto>().ReverseMap();
            CreateMap<AppointmentViewModel, AppointmentDto>().ReverseMap();
            CreateMap<GetAppointmentsRequestViewModel, GetAppointmentsRequestDto>().ReverseMap();
            CreateMap<CreateAppointmentDiagnosisRequestViewModel, CreateAppointmentDiagnosisRequestDto>().ReverseMap();
        }

    }
}
