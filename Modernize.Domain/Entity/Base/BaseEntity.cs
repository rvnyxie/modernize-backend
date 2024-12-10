using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Domain
{
    /// <summary>
    /// Base entity which provides some common attributes
    /// </summary
    public class BaseEntity
    {
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
