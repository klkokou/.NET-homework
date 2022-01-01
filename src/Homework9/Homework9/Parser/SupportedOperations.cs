using System.Collections.Generic;
using System.Linq.Expressions;

namespace Homework9.Parser
{
    public class SupportedOperations
    {
        public static readonly Dictionary<string, ExpressionType> supportedOperations = new()
        {
            { "+", ExpressionType.Add },
            { "-", ExpressionType.Subtract },
            { "*", ExpressionType.Multiply },
            { "/", ExpressionType.Divide },
            { "(", ExpressionType.Constant }
        };
    }
}