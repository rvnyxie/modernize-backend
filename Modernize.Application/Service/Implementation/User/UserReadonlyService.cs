using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Implementation of user readonly service
    /// </summary>
    public class UserReadonlyService : BaseReadonlyService<User, UserDto, Guid>, IUserReadonlyService
    {
        #region Declaration

        private IUserReadonlyRepository _userReadonlyRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserReadonlyService(IUserReadonlyRepository userReadonlyRepository, IMapper mapper) : base(userReadonlyRepository)
        {
            _userReadonlyRepository = userReadonlyRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<UserDto> GetCurrentAuthenticatedUserAsync(string userId)
        {
            var currentAuthenticatedUser = await _userReadonlyRepository.GetCurrentAuthenticatedUserAsync(userId);

            var currentAuthenticatedUserDto = MapEntityToDto(currentAuthenticatedUser);

            return currentAuthenticatedUserDto;
        }

        public override UserDto MapEntityToDto(User user)
        {
            return _mapper.Map<UserDto>(user);
        }

        #endregion
    }
}
