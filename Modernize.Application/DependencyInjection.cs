using Microsoft.Extensions.DependencyInjection;
using Modernize.Application.Commands.Product.Delete;

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
            services.AddScoped<IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupDto>>, GetAllProductGroupsQueryHandler>();

            // User
            services.AddScoped<IQueryHandler<GetUserInfoQuery, UserDto>, GetUserInfoQueryHandler>();

            #endregion

            #region Register command handler

            // Product
            services.AddScoped<ICommandHandler<CreateProductCommand, ProductDto>, CreateProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand, ProductDto>, UpdateProductCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand, int>, DeleteProductCommandHandler>();

            // Product Group
            services.AddScoped<ICommandHandler<CreateProductGroupCommand, ProductGroupDto>, CreateProductGroupCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductGroupCommand, ProductGroupDto>, UpdateProductGroupCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProductGroupCommand, int>, DeleteProductGroupCommandHandler>();

            // User
            services.AddScoped<ICommandHandler<CreateUserCommand, UserDto>, CreateUserCommandHandler>();
            services.AddScoped<ICommandHandler<LoginUserCommand, LoginSuccessDto>, LoginUserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateCurrentUserCommand, UserDto>, UpdateCurrentUserCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteCurrentUserCommand, int>, DeleteCurrentUserCommandHandler>();

            #region Register AutoMapper

            services.AddAutoMapper(typeof(MappingProductProfile));
            services.AddAutoMapper(typeof(MappingProductGroupProfile));
            services.AddAutoMapper(typeof(MappingUserProfile));

            #endregion

            #region Register entity services

            // Product
            services.AddScoped<IProductReadonlyService, ProductReadonlyService>();
            services.AddScoped<IProductService, ProductService>();

            // Product Group
            services.AddScoped<IProductGroupReadonlyService, ProductGroupReadonlyService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();

            // User
            services.AddScoped<IUserReadonlyService, UserReadonlyService>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            #endregion

            return services;
        }
    }
}
