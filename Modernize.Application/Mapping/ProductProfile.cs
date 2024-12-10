using AutoMapper;
using Modernize.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
