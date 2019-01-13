using Allergo.Home.Contracts;
using Allergo.Home.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allergo.Home
{
    public static class ServiceConfigurator
    {
        public static void RegisterHomeModule(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsService, StatisticsService>();
        }
    }
}
