using System;
using System.ComponentModel;

namespace TaskManager.Common.Enums {
    [Flags]
    public enum TaskStatus : byte {
        [Description("None")]
        None = 0,
        [Description("In Progress")]
        InProgress = 1,
        [Description("Done")]
        Done = 2,
        [Description("Need Feedback")]
        NeedFeedback = 4,
        [Description("Rejected")]
        Rejected = 8,

    }
}
