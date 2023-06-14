using CadCli.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadCli.Infra
{
    public static class InfraStructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddInfraRepositories();

            return services;
        }

        private static IServiceCollection AddInfraRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICadClientesRepository, CadClientesRepository>();

            return services;
        }
    }
}