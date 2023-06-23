using Microsoft.Extensions.DependencyInjection;
using Prontuarios.Application.InterfaceServices;
using Prontuarios.Application.Services;
using Prontuarios.Infra;

namespace Prontuarios.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProntuariosService, ProntuariosService>();
            services.AddInfrastructure();

            services.AddHttpClient(); // Adiciona o HttpClient como um serviço

            return services;
        }
    }
}
