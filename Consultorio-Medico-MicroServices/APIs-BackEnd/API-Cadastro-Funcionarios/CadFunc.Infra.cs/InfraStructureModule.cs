using CadFunc.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadFunc.Infra
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
            services.AddScoped<ICadMedicosRepository, CadMedicosRepository>();

            return services;
        }
    }
}