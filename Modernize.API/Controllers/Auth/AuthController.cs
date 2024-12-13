using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modernize.Application;
using Modernize.Infrastructure;

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

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtTokenGenerator _jwtGenerator;

        #endregion

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtTokenGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto userCreationDto)
        {
            var user = new ApplicationUser
            {
                UserName = userCreationDto.UserName,
                Email = userCreationDto.Email,
                FullName = userCreationDto.FullName,
                DateOfBirth = userCreationDto.DateOfBirth,
                Address = userCreationDto.Address,
                ProfilePictureUrl = userCreationDto.ProfilePictureUrl,
                Description = userCreationDto.Description,
            };

            var result = await _userManager.CreateAsync(user, userCreationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            return Ok(result.Succeeded);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid email or password");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = _jwtGenerator.GenerateToken(user, roles);

            return Ok(new { Token = token });
        }
    }
}
