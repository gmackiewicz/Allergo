using Allergo.Common.Contracts;
using Allergo.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allergo.Common
{
    public static class ServiceConfigurator
    {
        public static void RegisterCommonModule(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
        }
    }
}
