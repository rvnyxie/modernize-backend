using Microsoft.Extensions.DependencyInjection;
using Modernize.Application.Commands.Product.Delete;
using Modernize.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            // Register query handler
            // Product
            services.AddScoped<IQueryHandler<GetAllProductQuery, IEnumerable<Product>>, GetAllProductQueryHandler>();

            // Product Group
            services.AddScoped<IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>>, GetAllProductGroupsQueryHandler>();


            // Register command handler
            // Product
            services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();

            // Product Group
            services.AddScoped<ICommandHandler<CreateProductGroupCommand>, CreateProductGroupCommandHandler>();

            // AutoMapper
            services.AddAutoMapper(typeof(ProductProfile));

            return services;
        }
    }
}
