using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Allergo.Appointment.Dto;

namespace Allergo.Appointment.Contracts
{
    public interface IAppointmentService
    {
        Task CreateAppointmentAsync(CreateAppointmentRequestDto request);

        IList<AppointmentDto> GetUserAppointments(Guid userId, DateTime? beforeDate);

        IList<AppointmentDto> GetDoctorAppointments(Guid doctorId, DateTime? beforeDate);
        
        Task UpdateAppointmentAsync(Data.Models.Appointment.Appointment appointment);

        Task<Data.Models.Appointment.Appointment> GetAppointmentById(string id);
    }
}