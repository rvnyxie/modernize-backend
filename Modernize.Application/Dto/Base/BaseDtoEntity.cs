namespace Modernize.Application
{
    /// <summary>
    /// Base DTO entity
    /// </summary>
    public class BaseDtoEntity
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
