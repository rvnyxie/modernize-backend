namespace Modernize.Application
{
    public class BaseDtoEntity
    {
        #region Auditing

        public DateTimeOffset createdAt;

        public DateTimeOffset modifiedAt;

        public string? createdBy;

        public string? modifiedBy;

        #endregion
    }
}
