using Microsoft.AspNetCore.Mvc;
using Modernize.Application;

namespace Modernize.API.Controllers.Auth
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        #region Declaration

        private readonly ICommandHandler<LoginUserCommand, LoginSuccessDto> _loginUserHandler;
        private readonly ICommandHandler<CreateUserCommand, UserDto> _createUserHandler;

        #endregion

        #region Constructor

        public AuthController(ICommandHandler<LoginUserCommand, LoginSuccessDto> loginUserHandler, ICommandHandler<CreateUserCommand, UserDto> createUserHandler)
        {
            _loginUserHandler = loginUserHandler;
            _createUserHandler = createUserHandler;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="command">User creation command</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var createdUserDto = await _createUserHandler.HandleAsync(command);

            return Ok(createdUserDto);
        }

        /// <summary>
        /// Login with user credentials
        /// </summary>
        /// <param name="command">User login command</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginSuccessDto = await _loginUserHandler.HandleAsync(command);

            return Ok(loginSuccessDto);
        }

        #endregion
    }
}
