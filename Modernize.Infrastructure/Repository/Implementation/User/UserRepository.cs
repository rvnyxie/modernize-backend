using Microsoft.AspNetCore.Identity;
using Modernize.Application;
using Modernize.Domain;
using System.Net;

namespace Modernize.Infrastructure
{
    public class UserRepository : UserReadonlyRepositoryEFCore, IUserRepository
    {
        #region Declaration

        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        #endregion

        #region Constructor

        public UserRepository(
            AppDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtTokenGenerator jwtTokenGenerator) : base(dbContext)
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

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> UpdateManyAsync(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DELETE

        public Task<int> DeleteAsync(User user)
        {
            throw new NotImplementedException();
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
            await _userManager.CreateAsync(user, password);

            await _userManager.AddToRoleAsync(user, "Customer");

            return user;
        }

        #endregion

        #endregion
    }
}
