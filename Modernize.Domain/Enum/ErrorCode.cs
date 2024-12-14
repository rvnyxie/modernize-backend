using System.ComponentModel;

namespace Modernize.Domain
{
    /// <summary>
    /// Error codes enum
    /// </summary>
    public enum ErrorCode
    {
        [Description("Bad credentials provided")]
        BAD_CREDENTIALS,

        [Description("Entity not found")]
        ENTITY_NOT_FOUND,

        [Description("Unknown exception")]
        UNHANDLED
    }
}
