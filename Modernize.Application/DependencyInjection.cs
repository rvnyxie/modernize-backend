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
            services.AddScoped<IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>>, GetAllProductQueryHandler>();

            // Product Group
            services.AddScoped<IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>>, GetAllProductGroupsQueryHandler>();


            // Register command handler
            // Product
            services.AddScoped<ICommandHandler<CreateProductCommand, ProductDto>, CreateProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand, ProductDto>, UpdateProductCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand, int>, DeleteProductCommandHandler>();

            // Product Group
            services.AddScoped<ICommandHandler<CreateProductGroupCommand, ProductGroup>, CreateProductGroupCommandHandler>();

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProductProfile));

            // Resgister services
            // Product
            services.AddScoped<IProductReadonlyService, ProductReadonlyService>();
            services.AddScoped<IProductService, ProductService>();

            // Product Group
            services.AddScoped<IProductGroupReadonlyService, ProductGroupReadonlyService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();

            return services;
        }
    }
}
