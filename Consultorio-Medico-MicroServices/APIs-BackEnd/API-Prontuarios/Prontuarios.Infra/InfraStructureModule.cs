using Microsoft.Extensions.DependencyInjection;
using Prontuarios.Infra.Repositories;

namespace Prontuarios.Infra
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
            services.AddScoped<IProntuariosRepository, ProntuariosRepository>();

            return services;
        }
    }       
}