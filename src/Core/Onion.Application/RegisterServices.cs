using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterServices).Assembly));
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
