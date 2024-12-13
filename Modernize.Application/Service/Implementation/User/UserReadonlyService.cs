using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class UserReadonlyService : BaseReadonlyService<User, UserDto, Guid>, IUserReadonlyService
    {
        private readonly IMapper _mapper;

        public UserReadonlyService(IUserReadonlyRepository userReadonlyRepository, IMapper mapper) : base(userReadonlyRepository)
        {
            _mapper = mapper;
        }

        public override UserDto MapEntityToDto(User user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}
