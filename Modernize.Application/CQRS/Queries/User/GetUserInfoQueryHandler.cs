namespace Modernize.Application
{
    /// <summary>
    /// Handler of getting user info
    /// </summary>
    public class GetUserInfoQueryHandler : IQueryHandler<GetUserInfoQuery, UserDto>
    {
        private readonly IUserReadonlyService _userReadonlyService;

        public GetUserInfoQueryHandler(IUserReadonlyService userReadonlyService)
        {
            _userReadonlyService = userReadonlyService;
        }

        public async Task<UserDto> HandleAsync(GetUserInfoQuery query)
        {
            var currentAuthenticatedUserDtos = await _userReadonlyService.GetCurrentAuthenticatedUserAsync(query.UserId);

            return currentAuthenticatedUserDtos;
        }
    }
}
