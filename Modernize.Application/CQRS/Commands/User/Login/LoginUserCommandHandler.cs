using AutoMapper;

namespace Modernize.Application
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginSuccessDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<LoginSuccessDto> HandleAsync(LoginUserCommand command)
        {
            var loginDto = _mapper.Map<LoginDto>(command);

            var token = await _userService.Login(loginDto);

            var loginSuccessCredentailsDto = new LoginSuccessDto()
            {
                AccessToken = token
            };

            return loginSuccessCredentailsDto;
        }
    }
}
