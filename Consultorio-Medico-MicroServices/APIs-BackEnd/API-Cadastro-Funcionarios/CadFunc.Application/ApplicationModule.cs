﻿using CadFunc.Application.InterfacesServices;
using CadFunc.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CadFunc.Application
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
            services.AddScoped<ICadMedicosService, CadMedicosService>();

            return services;
        }
    }
}
