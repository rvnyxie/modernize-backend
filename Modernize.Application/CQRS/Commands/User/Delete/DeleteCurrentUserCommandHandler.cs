namespace Modernize.Application
{
    /// <summary>
    /// Command handler of deleting current user
    /// </summary>
    public class DeleteCurrentUserCommandHandler : ICommandHandler<DeleteCurrentUserCommand, int>
    {
        #region Declaration

        private readonly IUserService _userService;

        #endregion

        #region Constructor
        public DeleteCurrentUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        public async Task<int> HandleAsync(DeleteCurrentUserCommand command)
        {
            var rowsAffected = await _userService.DeleteByIdAsync(command.Id);

            return rowsAffected;
        }

        #endregion
    }
}
