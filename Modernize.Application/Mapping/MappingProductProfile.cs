using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class MappingProductProfile : Profile
    {
        public MappingProductProfile()
        {
            CreateMap<CreateProductCommand, ProductCreationDto>();
            CreateMap<UpdateProductCommand, ProductUpdateDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreationDto, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductUpdateDto, ProductDto>();
            CreateMap<ProductCreationDto, Product>()
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
