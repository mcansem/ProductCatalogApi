using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalogManagerAPI.Application.Abstraction;
using ProductCatalogManagerAPI.Persistence.Context;
using ProductCatalogManagerAPI.Persistence.Concrete;
using ProductCatalogManagerAPI.Persistence.Repository;
using System.Reflection;
using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Application.Mappers;

namespace ProductCatalogManagerAPI.Persistence
{
    /// <summary>
    /// Service registration class. handles service registrations for program.cs file
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Adds persistence services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(Configuration.ConnectionString, option =>
            {
                option.MigrationsAssembly(Assembly.GetAssembly(typeof(BaseDbContext)).GetName().Name);
            }), ServiceLifetime.Scoped);

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}