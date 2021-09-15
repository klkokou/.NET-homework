using System;

namespace Homework1
{
    public enum SupportedOperations
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }

    public static class Calculator
    {
        public static double Calculate(SupportedOperations operation, int val1, int val2)
        {
            var result = 0.0;
            switch (operation)
            {
                case SupportedOperations.Plus:
                    result = val1 + val2;
                    break;
                case SupportedOperations.Minus:
                    result = val1 - val2;
                    break;
                case SupportedOperations.Multiply:
                    result = val1 * val2;
                    break;
                case SupportedOperations.Divide:
                    if (val2 != 0)
                        result = (double)val1 / val2;
                    break;
            }

            return result;
        }
    }
}