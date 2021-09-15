using System;

namespace Homework1
{
    public static class Calculator
    {
        public enum SupportedOperations
        {
            Plus,
            Minus,
            Divide,
            Multiply,
        }

        public static double Calculate(int val1, SupportedOperations operation, int val2)
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
                    result = (double)val1 / val2;
                    break;
            }

            return result;
        }
    }
}