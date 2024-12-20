﻿using Microsoft.AspNetCore.Identity;

namespace Modernize.Domain
{
    public class User : IdentityUser
    {
        #region Personal info

        public string? FullName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Description { get; set; }

        #endregion

        #region Auditing

        /// <summary>
        /// Created date time
        /// </summary>
        public DateTimeOffset CreatedAt;

        /// <summary>
        /// Modified date time
        /// </summary
        public DateTimeOffset ModifiedAt;

        /// <summary>
        /// User who creates
        /// </summary>
        public string? CreatedBy;

        /// <summary>
        /// User who modifies
        /// </summary>
        public string? ModifiedBy;

        #endregion
    }
}
