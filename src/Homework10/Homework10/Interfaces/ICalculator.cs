using Homework10.Calculator;

namespace Homework10.Interfaces
{
    public interface ICalculator
    {
        public Answer<string, string> Calculate(string expression);
    }
}