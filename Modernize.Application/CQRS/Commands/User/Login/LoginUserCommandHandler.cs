using AutoMapper;

namespace Modernize.Application
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginSuccessCredentialsDto>
    {
        private readonly IUserService<LoginDto> _userService;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserService<LoginDto> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<LoginSuccessCredentialsDto> HandleAsync(LoginUserCommand command)
        {
            var loginDto = _mapper.Map<LoginDto>(command);

            var token = await _userService.Login(loginDto);

            var loginSuccessCredentailsDto = new LoginSuccessCredentialsDto()
            {
                Token = token
            };

            return loginSuccessCredentailsDto;
        }
    }
}
