using System.Collections.Generic;

namespace Homework10
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