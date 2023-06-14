using CadCli.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using CadCli.Infra;

namespace CadCli.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICadClientesService, CadClientesService>();
            services.AddInfrastructure();

            return services;
        }
    }
}
