using System.Globalization;
using Homework8.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator calculator;
        private readonly IParser parser;
        private IInput input;
        
        public CalculatorController( ICalculator calculator, IParser parser, IInput input)
        {
            this.calculator = calculator;
            this.parser = parser;
            this.input = input;
        }
        
        public IActionResult Calculate(string value1, string operation, string value2)
        {
            parser.ParseArgs(value1, operation, value2, ref input);
            if (string.IsNullOrEmpty(input.ErrorMessage))
                return Content(calculator.Calculate(input).ToString(CultureInfo.InvariantCulture));
            return BadRequest(input.ErrorMessage);
        }
    }
}