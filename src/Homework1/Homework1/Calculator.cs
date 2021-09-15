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

        public static bool Calculate(int val1, SupportedOperations supportedOperations, int val2, out int result)
        {
            result = 0;
            switch (supportedOperations)
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
                    if (val2 == 0)
                    {
                        return true;
                    }

                    result = val1 / val2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(supportedOperations), supportedOperations, null);
            }

            return false;
        }
    }
}