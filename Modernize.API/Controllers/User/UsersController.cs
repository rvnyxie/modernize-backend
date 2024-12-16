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

        #endregion

        #region Constructor

        public UsersController(UserManager<User> userManager, IQueryHandler<GetUserInfoQuery, UserDto> getUserInfoHandler)
        {
            _userManager = userManager;
            _getUserInfoHandler = getUserInfoHandler;
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

        #endregion
    }
}
