using System;
using System.Collections.Generic;
using System.Text;

namespace StressTestFramework.Models
{
    public enum HttpVerb
    {
        None = 0,
        Delete = 1,
        Get = 2,
        Head = 3,
        Options = 4,
        Patch = 5,
        Post = 6,
        Put = 7,
        Trace = 8,
        Connect = 9
    }
}
