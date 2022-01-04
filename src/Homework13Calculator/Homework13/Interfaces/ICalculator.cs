
using Homework13.Calculator;

namespace Homework13.Interfaces
{
    public interface ICalculator
    {
        public Answer<string, string> Calculate(string expression);
    }
}