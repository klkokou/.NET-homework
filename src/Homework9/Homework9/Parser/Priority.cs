using System.Collections.Generic;

namespace Homework9.Parser
{
    public class Priority
    {
        public static readonly Dictionary<string, int> priority = new()
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "(", 0 }
        };
    }
}