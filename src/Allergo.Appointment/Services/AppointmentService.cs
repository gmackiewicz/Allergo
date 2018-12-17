using Allergo.Appointment.Contracts;
using Allergo.Appointment.Dto;
using Allergo.Common.Contracts;
using Allergo.Data.Contracts;
using System.Threading.Tasks;

namespace Allergo.Appointment.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDataService _dataService;
        private readonly IDoctorService _doctorService;

        public AppointmentService(
            IDataService dataService,
            IDoctorService doctorService)
        {
            _dataService = dataService;
            _doctorService = doctorService;
        }

        public async Task CreateAppointmentAsync(CreateAppointmentRequestDto request)
        {
            var doctor = await _doctorService.GetDoctorAsync(request.DoctorId);

            var newAppointment = new Data.Models.Appointment.Appointment
            {
                Doctor = doctor,
                Date = request.Date,
                UserId =  request.UserId
            };

            await _dataService.GetSet<Data.Models.Appointment.Appointment>().AddAsync(newAppointment);
            await _dataService.SaveDbAsync();
        }
    }
}
