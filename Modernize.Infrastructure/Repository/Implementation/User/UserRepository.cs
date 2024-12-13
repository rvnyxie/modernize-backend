using Microsoft.AspNetCore.Identity;
using Modernize.Application;
using Modernize.Domain;

namespace Modernize.Infrastructure
{
    public class UserRepository : UserReadonlyRepositoryEFCore, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

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

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> UpdateManyAsync(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyAsync(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return "Invalid email or password";
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!result.Succeeded)
            {
                return "Invalid email or password";
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            return token;
        }
    }
}
