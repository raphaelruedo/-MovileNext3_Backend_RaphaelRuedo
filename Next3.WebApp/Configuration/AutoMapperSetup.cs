using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Next3.Application.AutoMapper;
using System;

namespace Next3.WebApp.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}
