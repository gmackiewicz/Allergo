using Allergo.Data.Contracts;
using Allergo.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allergo.Data
{
    public static class ServiceConfigurator
    {
        public static void RegisterDataModule(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
        }
    }
}
