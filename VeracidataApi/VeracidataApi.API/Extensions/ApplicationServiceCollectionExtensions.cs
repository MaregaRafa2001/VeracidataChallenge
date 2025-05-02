using VeracidataApi.Application.Interfaces;
using VeracidataApi.Application.Services;

namespace VeracidataApi.API.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
