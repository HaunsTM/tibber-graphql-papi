using System.ComponentModel;

namespace Data.Enum
{
    public enum Level
    {
        [Description("VERY_CHEAP")]
        VERY_CHEAP = 1,
        [Description("CHEAP")]
        CHEAP = 2,
        [Description("NORMAL")]
        NORMAL = 3,
        [Description("EXPENSIVE")]
        EXPENSIVE = 4,
        [Description("VERY_EXPENSIVE")]
        VERY_EXPENSIVE = 5

    }
}
