using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeracidataApi.Domain.Interfaces;
using VeracidataApi.Infrastructure.Connection;
using VeracidataApi.Infrastructure.Repositories;
using VeracidataApi.Infrastructure.Settings;

namespace VeracidataApi.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            services.AddScoped<IDbConnection>(sp =>
                sp.GetRequiredService<IDbConnectionFactory>().CreateConnection());

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
