namespace VeracidataApi.API.Extensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return Infrastructure.DependencyInjection
                .InfrastructureServiceCollectionExtensions
                .AddInfrastructureServices(services, configuration);

        }
    }
}
