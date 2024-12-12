namespace Modernize.Application
{
    public class UserUpdateDto
    {
        #region Personal info

        public string? FullName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Description { get; set; }

        #endregion
    }
}
