using Microsoft.AspNetCore.Identity;
using Modernize.Application;
using Modernize.Domain;
using System.Net;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Implementation of user repository using EF Core
    /// </summary>
    public class UserRepository : UserReadonlyRepositoryEFCore, IUserRepository
    {
        #region Declaration

        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtTokenGenerator;

        #endregion

        #region Constructor

        public UserRepository(
            AppDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtTokenService jwtTokenGenerator) : base(dbContext, userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        #endregion

        #region Methods

        #region INSERT

        public async Task<User> InsertAsync(User user)
        {
            await _userManager.CreateAsync(user);

            await _userManager.AddToRoleAsync(user, "Customer");

            return user;
        }

        public Task<IEnumerable<User>> InsertManyAsync(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region UPDATE

        public async Task<User> UpdateAsync(User user)
        {
            var updatingResult = await _userManager.UpdateAsync(user);

            if (!updatingResult.Succeeded)
            {
                throw new UserModificationException(
                    ErrorCode.BAD_MODIFICATION,
                    HttpStatusCode.BadRequest,
                    "Unable to update user",
                    updatingResult.Errors
                );
            }

            return user;
        }

        public Task<IEnumerable<User>> UpdateManyAsync(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DELETE

        public async Task<int> DeleteAsync(User user)
        {
            var deletingResult = await _userManager.DeleteAsync(user);

            if (!deletingResult.Succeeded)
            {
                throw new UserModificationException(
                    ErrorCode.BAD_MODIFICATION,
                    HttpStatusCode.BadRequest,
                    "Unable to delete user",
                    deletingResult.Errors
                );
            }

            return 1;
        }

        public Task<int> DeleteManyAsync(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region OTHERS

        public async Task<string> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new InvalidCredentialException(
                    ErrorCode.BAD_CREDENTIALS,
                    HttpStatusCode.BadRequest,
                    "Invalid email or password"
                );
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!result.Succeeded)
            {
                throw new InvalidCredentialException(
                    ErrorCode.BAD_CREDENTIALS,
                    HttpStatusCode.BadRequest,
                    "Invalid email or password"
                );
            }

            var roles = await _userManager.GetRolesAsync(user);

            var accessToken = _jwtTokenGenerator.GenerateToken(user, roles);

            return accessToken;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            var userCreationResult = await _userManager.CreateAsync(user, password);

            if (!userCreationResult.Succeeded)
            {
                throw new InvalidCredentialException(
                    ErrorCode.BAD_CREDENTIALS,
                    HttpStatusCode.BadRequest,
                    "Invalid user information provided",
                    userCreationResult.Errors
                );
            }

            var userRoleCreatioResult = await _userManager.AddToRoleAsync(user, "Customer");

            if (!userRoleCreatioResult.Succeeded)
            {
                throw new InvalidCredentialException(
                    ErrorCode.BAD_CREDENTIALS,
                    HttpStatusCode.BadRequest,
                    "Can't add user role"
                );
            }
            return user;
        }

        #endregion

        #endregion
    }
}
