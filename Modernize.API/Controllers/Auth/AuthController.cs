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

        private readonly ICommandHandler<LoginUserCommand, LoginSuccessCredentialsDto> _loginUserHandler;

        #endregion

        #region Constructor

        public AuthController(ICommandHandler<LoginUserCommand, LoginSuccessCredentialsDto> loginUserHandler)
        {
            _loginUserHandler = loginUserHandler;
        }

        #endregion

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto userCreationDto)
        {
            //var user = new ApplicationUser
            //{
            //    UserName = userCreationDto.UserName,
            //    Email = userCreationDto.Email,
            //    FullName = userCreationDto.FullName,
            //    DateOfBirth = userCreationDto.DateOfBirth,
            //    Address = userCreationDto.Address,
            //    ProfilePictureUrl = userCreationDto.ProfilePictureUrl,
            //    Description = userCreationDto.Description,
            //};

            //var result = await _userManager.CreateAsync(user, userCreationDto.Password);
            //_userManager.

            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            //await _userManager.AddToRoleAsync(user, "Customer");

            //return Ok(result.Succeeded);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginSuccessCredentialsDto = await _loginUserHandler.HandleAsync(command);

            return Ok(loginSuccessCredentialsDto);
        }
    }
}
