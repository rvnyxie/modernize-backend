using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// User mapping profile used for AutoMapper
    /// </summary>
    public class MappingUserProfile : Profile
    {
        public MappingUserProfile()
        {
            // Query, Command
            CreateMap<CreateUserCommand, UserCreationDto>();
            CreateMap<LoginUserCommand, LoginDto>();
            CreateMap<UpdateCurrentUserCommand, UserUpdateDto>();

            // To Entity
            CreateMap<UserCreationDto, User>();
            CreateMap<UserUpdateDto, User>();

            // To DTO
            CreateMap<User, UserDto>();
        }
    }
}
