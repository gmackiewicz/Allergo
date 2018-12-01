using Allergo.Schedule.Contracts;
using Allergo.Schedule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allergo.Schedule
{
    public static class ServiceConfigurator
    {
        public static void RegisterScheduleModule(this IServiceCollection services)
        {
            services.AddScoped<IScheduleService, ScheduleService>();
        }
    }
}
