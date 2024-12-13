using Modernize.Domain;

namespace Modernize.Infrastructure
{
    public class UserReadonlyRepositoryEFCore : BaseReadonlyRepositoryEFCore<User, Guid>, IUserReadonlyRepository
    {
        public UserReadonlyRepositoryEFCore(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
