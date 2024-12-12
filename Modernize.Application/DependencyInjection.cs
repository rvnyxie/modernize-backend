using Microsoft.Extensions.DependencyInjection;
using Modernize.Application.Commands.Product.Delete;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Application dependency injections declaration
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Unified method used to add dependency injections in Application
        /// </summary>
        /// <param name="services">Application builder services</param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Register query handler

            // Product
            services.AddScoped<IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>>, GetAllProductQueryHandler>();

            // Product Group
            services.AddScoped<IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>>, GetAllProductGroupsQueryHandler>();

            #endregion

            #region Register command handler

            // Product
            services.AddScoped<ICommandHandler<CreateProductCommand, ProductDto>, CreateProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand, ProductDto>, UpdateProductCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand, int>, DeleteProductCommandHandler>();

            // Product Group
            services.AddScoped<ICommandHandler<CreateProductGroupCommand, ProductGroup>, CreateProductGroupCommandHandler>();

            #region Register AutoMapper

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProductProfile));

            #endregion

            #region Register entity services

            // Product
            services.AddScoped<IProductReadonlyService, ProductReadonlyService>();
            services.AddScoped<IProductService, ProductService>();

            // Product Group
            services.AddScoped<IProductGroupReadonlyService, ProductGroupReadonlyService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();

            #endregion

            #endregion

            return services;
        }
    }
}
