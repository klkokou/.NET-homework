using System.Collections.Generic;

namespace Homework10
{
    public class ErrorMessages
    {
        public static readonly Dictionary<int, string> errorMessages = new ()
        {
            {1,"Empty input"},
            {2,"There are two operations in a row"},
            {3,"Check brackets"},
            {4, "Invalid input"}
        };
    }
}