using Microsoft.AspNetCore.Identity;
using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Implementation of user readonly repository using EF Core
    /// </summary>
    public class UserReadonlyRepositoryEFCore : BaseReadonlyRepositoryEFCore<User, Guid>, IUserReadonlyRepository
    {
        #region Declaration

        private readonly UserManager<User> _userManager;

        #endregion

        #region Constructor

        public UserReadonlyRepositoryEFCore(AppDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        #endregion

        #region Methods

        public async Task<User> GetCurrentAuthenticatedUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new UserNotFoundException(
                    ErrorCode.ENTITY_NOT_FOUND,
                    System.Net.HttpStatusCode.NotFound,
                    "User not found"
                );
            }

            return user;
        }

        #endregion
    }
}
