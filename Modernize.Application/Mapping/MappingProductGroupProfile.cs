using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group mapping profile used for AutoMapper
    /// </summary>
    public class MappingProductGroupProfile : Profile
    {
        public MappingProductGroupProfile()
        {
            // Query, Command
            CreateMap<CreateProductGroupCommand, ProductGroupCreationDto>();
            CreateMap<UpdateProductGroupCommand, ProductGroupUpdateDto>();

            // To Entity
            CreateMap<ProductGroupCreationDto, ProductGroup>();
            CreateMap<ProductGroupUpdateDto, ProductGroup>();

            // To DTO
            CreateMap<ProductGroup, ProductGroupDto>();
        }
    }
}
