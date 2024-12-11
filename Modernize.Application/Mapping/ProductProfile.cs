using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.Group, opt => opt.Ignore());
        }
    }
}
