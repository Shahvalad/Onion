using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces;
using Onion.Persistance.Context;
using Onion.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance
{
    public static class RegisterServices
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase("memoryDb"));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
