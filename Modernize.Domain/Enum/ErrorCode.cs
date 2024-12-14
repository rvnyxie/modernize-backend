using System.ComponentModel;

namespace Modernize.Domain
{
    /// <summary>
    /// Error codes enum
    /// </summary>
    public enum ErrorCode
    {
        [Description("Bad credentials provided")]
        BAD_CREDENTIALS = 4001,

        [Description("Entity not found")]
        ENTITY_NOT_FOUND = 4041,

        [Description("Unknown exception")]
        UNHANDLED = 5000
    }
}
