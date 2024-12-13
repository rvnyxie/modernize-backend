using Modernize.Domain;

namespace Modernize.Application
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IList<string> roles);
    }
}
