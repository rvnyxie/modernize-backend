using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modernize.Application;
using Modernize.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modernize.Infrastructure
{
    public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
    {
        private readonly string _secretKey = configuration["JwtSettings:SecretKey"];
        private readonly string _issuer = configuration["JwtSettings:Issuer"];
        private readonly string _audience = configuration["JwtSettings:Audience"];

        public String GenerateToken(User user, IList<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            // Add role claims
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
