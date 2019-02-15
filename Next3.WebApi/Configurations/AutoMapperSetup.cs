using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Next3.Application.AutoMapper;

namespace Next3.WebApi.Configurations
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
