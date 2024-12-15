using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modernize.Application;
using Modernize.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Implementation for JWT service
    /// </summary>
    /// <param name="configuration">Application's configuration</param>
    public class JwtTokenService : IJwtTokenService
    {
        #region Declaration

        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly double _lifeTimeInMinutes;

        #endregion

        #region Constructor

        public JwtTokenService(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"]
                ?? throw new ArgumentNullException(nameof(configuration), "SecretKey is missing in configuration.");
            _issuer = configuration["JwtSettings:Issuer"]
              ?? throw new ArgumentNullException(nameof(configuration), "Issuer is missing in configuration.");
            _audience = configuration["JwtSettings:Audience"]
                        ?? throw new ArgumentNullException(nameof(configuration), "Audience is missing in configuration.");
            if (!double.TryParse(configuration["JwtSettings:LifeTimeInMinutes"], out _lifeTimeInMinutes))
            {
                throw new ArgumentException("Invalid LifeTimeInMinutes value in configuration.");
            }
        }

        #endregion

        #region Methods

        public String GenerateToken(User user, IList<string> roles)
        {
            try
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
                    expires: DateTime.UtcNow.AddMinutes(_lifeTimeInMinutes),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error generating JWT token", ex);
            }
        }

        #endregion
    }
}
