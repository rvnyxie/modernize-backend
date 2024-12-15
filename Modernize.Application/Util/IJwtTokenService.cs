using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Interface for JWT service
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Generate token based on user information and user's roles
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="roles">User's roles</param>
        /// <returns>Generated token</returns>
        string GenerateToken(User user, IList<string> roles);
    }
}
