using Allergo.Appointment.Contracts;
using Allergo.Appointment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allergo.Appointment
{
    public static class ServiceConfigurator
    {
        public static void RegisterAppointmentModule(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
        }
    }
}
