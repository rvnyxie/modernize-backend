using AutoMapper;

namespace Modernize.Application
{
    /// <summary>
    /// User creation command handler
    /// </summary>
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        #region Declaration

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<UserDto> HandleAsync(CreateUserCommand command)
        {
            var userCreationDto = _mapper.Map<UserCreationDto>(command);

            var createdUserDto = await _userService.InsertAsync(userCreationDto);

            return createdUserDto;
        }

        #endregion
    }
}
