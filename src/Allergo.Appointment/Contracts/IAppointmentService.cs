using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Allergo.Appointment.Dto;

namespace Allergo.Appointment.Contracts
{
    public interface IAppointmentService
    {
        Task CreateAppointmentAsync(CreateAppointmentRequestDto request);

        IList<AppointmentDto> GetAppointments(Guid userId);
    }
}