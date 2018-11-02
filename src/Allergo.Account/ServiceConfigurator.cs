using Allergo.Account.Contracts;
using Allergo.Account.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allergo.Account
{
    public static class ServiceConfigurator
    {
        public static void RegisterAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthValidationService, AuthValidationService>();
        }
    }
}
