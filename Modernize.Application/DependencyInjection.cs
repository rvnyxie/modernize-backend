using Microsoft.Extensions.DependencyInjection;
using Modernize.Application.Commands.Product.Delete;
using Modernize.Domain;

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
            services.AddScoped<ICommandHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand, Product>, UpdateProductCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand, int>, DeleteProductCommandHandler>();

            // Product Group
            services.AddScoped<ICommandHandler<CreateProductGroupCommand, ProductGroup>, CreateProductGroupCommandHandler>();

            // AutoMapper
            services.AddAutoMapper(typeof(ProductProfile));

            return services;
        }
    }
}
