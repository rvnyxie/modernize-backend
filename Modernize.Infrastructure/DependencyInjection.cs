using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}
