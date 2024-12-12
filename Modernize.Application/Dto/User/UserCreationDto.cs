namespace Modernize.Application
{
    public class UserCreationDto
    {
        #region Personal info

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FullName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Description { get; set; }

        #endregion
    }
}
