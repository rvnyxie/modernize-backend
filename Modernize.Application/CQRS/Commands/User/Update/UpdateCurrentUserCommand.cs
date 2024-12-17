namespace Modernize.Application
{
    /// <summary>
    /// Command of updating current authenticated user
    /// </summary>
    public class UpdateCurrentUserCommand : ICommand<UserDto>
    {
        #region Personal info

        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string? FullName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Description { get; set; }

        #endregion
    }
}
