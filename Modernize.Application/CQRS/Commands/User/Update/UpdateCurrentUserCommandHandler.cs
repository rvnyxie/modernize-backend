using AutoMapper;

namespace Modernize.Application
{
    /// <summary>
    /// Command handler of updating current user
    /// </summary>
    public class UpdateCurrentUserCommandHandler : ICommandHandler<UpdateCurrentUserCommand, UserDto>
    {
        #region Declaration

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public UpdateCurrentUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<UserDto> HandleAsync(UpdateCurrentUserCommand command)
        {
            var userUpdateDto = _mapper.Map<UserUpdateDto>(command);

            var currentUpdatedAuthenticatedUserDto = await _userService.UpdateAsync(userUpdateDto);

            return currentUpdatedAuthenticatedUserDto;
        }

        #endregion
    }
}
