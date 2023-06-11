using CadCli.Application.InterfacesServices;
using CadCli.Application.Services;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
