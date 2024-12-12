using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Product mapping profile used for AutoMapper
    /// </summary>
    public class MappingProductProfile : Profile
    {
        public MappingProductProfile()
        {
            // Query, Command
            CreateMap<CreateProductCommand, ProductCreationDto>();
            CreateMap<UpdateProductCommand, ProductUpdateDto>();

            // To Entity
            CreateMap<ProductCreationDto, Product>()
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductUpdateDto, Product>();

            // To DTO
            CreateMap<Product, ProductDto>();
        }
    }
}
