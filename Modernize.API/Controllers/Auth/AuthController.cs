using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modernize.Application;
using Modernize.Infrastructure;

namespace Modernize.API.Controllers.Auth
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto userCreationDto)
        {
            var user = new ApplicationUser
            {
                Email = userCreationDto.Email,
                PasswordHash = userCreationDto.Password,
                FullName = userCreationDto.FullName,
                DateOfBirth = userCreationDto.DateOfBirth,
                Address = userCreationDto.Address,
                ProfilePictureUrl = userCreationDto.ProfilePictureUrl,
                Description = userCreationDto.Description
            };

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            return Ok(result.Succeeded);
        }
    }
}
