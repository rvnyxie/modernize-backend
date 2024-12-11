using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, ProductCreationDto>();
            CreateMap<UpdateProductCommand, ProductUpdateDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
