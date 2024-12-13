using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class UserService : BaseService<User, UserDto, UserCreationDto, UserUpdateDto, Guid>, IUserService<LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(userRepository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<string> Login(LoginDto loginDto)
        {
            var token = _userRepository.Login(loginDto.Email, loginDto.Password);

            return token;
        }

        public override User MapCreationDtoToEntity(UserCreationDto? userCreationDto)
        {
            return _mapper.Map<User>(userCreationDto);
        }

        public override UserDto MapEntityToDto(User user)
        {
            return _mapper.Map<UserDto>(user);
        }

        public override User MapUpdateDtoToEntity(UserUpdateDto userUpdateDto)
        {
            return _mapper.Map<User>(userUpdateDto);
        }
    }
}
