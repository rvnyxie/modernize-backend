using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modernize.Application;
using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Infrastructure dependency injections declaration
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Unified method used to add dependency injections in Infrastructure
        /// </summary>
        /// <param name="services">Application builder services</param>
        /// <param name="configuration">Application configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register AppDbContext with MariaDB configuration

            services.AddDbContext<AppDbContext>(
                options => options.UseMySql(
                    configuration.GetConnectionString("MariaDbConnection"),
                    new MySqlServerVersion(new Version(11, 4))
                ));

            #endregion

            #region Register Repository

            // Product
            services.AddScoped<IProductReadonlyRepository, ProductReadonlyRepositoryDapper>();
            services.AddScoped<IProductRepository, ProductRepositoryEFCore>();

            // Product Group
            services.AddScoped<IProductGroupReadonlyRepository, ProductGroupReadonlyRepositoryDapper>();
            services.AddScoped<IProductGroupRepository, ProductGroupRepositoryEFCore>();

            // User
            services.AddScoped<IUserReadonlyRepository, UserReadonlyRepositoryEFCore>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region Register Unit Of Work

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            return services;
        }
    }
}
