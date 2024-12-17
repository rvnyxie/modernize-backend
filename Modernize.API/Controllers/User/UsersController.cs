using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modernize.Application;
using Modernize.Domain;
using System.Security.Claims;

namespace Modernize.API
{
    /// <summary>
    /// Users controller
    /// </summary>
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        #region Declartion

        private readonly UserManager<User> _userManager;

        private readonly IQueryHandler<GetUserInfoQuery, UserDto> _getUserInfoHandler;

        private readonly ICommandHandler<UpdateCurrentUserCommand, UserDto> _updateCurrentUserHandler;
        private readonly ICommandHandler<DeleteCurrentUserCommand, int> _deleteCurrentUserHandler;

        #endregion

        #region Constructor

        public UsersController(
            UserManager<User> userManager,
            IQueryHandler<GetUserInfoQuery, UserDto> getUserInfoHandler,
            ICommandHandler<UpdateCurrentUserCommand, UserDto> updateCurrentUserHandler,
            ICommandHandler<DeleteCurrentUserCommand, int> deleteCurrentUserHandler)
        {
            _userManager = userManager;
            _getUserInfoHandler = getUserInfoHandler;
            _updateCurrentUserHandler = updateCurrentUserHandler;
            _deleteCurrentUserHandler = deleteCurrentUserHandler;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get current authenticated user information
        /// </summary>
        /// <returns>Current authenticated user DTO</returns>
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("I dont think this can happen");
            }

            var query = new GetUserInfoQuery() { UserId = userId };


            var currentAuthenticatedUserDto = await _getUserInfoHandler.HandleAsync(query);

            return Ok(currentAuthenticatedUserDto);
        }

        /// <summary>
        /// Update current authenticated user
        /// </summary>
        /// <param name="command">Command of updating current authenticated user</param>
        /// <returns>Current updated user DTO</returns>
        [HttpPost("me")]
        public async Task<IActionResult> UpdateCurrentAuthenticatedUser(UpdateCurrentUserCommand command)
        {
            var currentUpdatedAuthenticatedUserDto = await _updateCurrentUserHandler.HandleAsync(command);

            return Ok(currentUpdatedAuthenticatedUserDto);
        }

        /// <summary>
        /// Delete current authenticated user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Rows affected</returns>
        [HttpDelete("me/{id}")]
        public async Task<IActionResult> DeleteCurrentAuthenticatedUser(string id)
        {
            var deleteCurrentUserCommand = new DeleteCurrentUserCommand() { Id = Guid.Parse(id) };

            var rowsAffected = await _deleteCurrentUserHandler.HandleAsync(deleteCurrentUserCommand);

            return Ok(rowsAffected);
        }

        #endregion
    }
}
