using Homework9.Calculator;

namespace Homework9.Interfaces
{
    public interface ICalculator
    {
        public Answer<string, string> Calculate(string expression);
    }
}