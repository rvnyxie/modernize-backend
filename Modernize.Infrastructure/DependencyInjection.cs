using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modernize.Domain;

namespace Modernize.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register AppDbContext with MariaDB configuration
            services.AddDbContext<AppDbContext>(
                options => options.UseMySql(
                    configuration.GetConnectionString("MariaDbConnection"),
                    new MySqlServerVersion(new Version(11, 4))
                ));

            // Register Repository
            // Product
            services.AddScoped<IProductReadonlyRepository, ProductReadonlyRepositoryEFCore>();
            services.AddScoped<IProductRepository, ProductRepositoryEFCore>();

            // Product Group
            services.AddScoped<IProductGroupReadonlyRepository, ProductGroupReadonlyRepositoryEFCore>();
            services.AddScoped<IProductGroupRepository, ProductGroupRepositoryEFCore>();

            return services;
        }
    }
}
