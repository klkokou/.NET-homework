using Homework13.Calculator;
using Homework13.Interfaces;
using Homework13.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework13.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator calculator;

        public CalculatorController(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            var answer = calculator.Calculate(expression);
            var model = answer.AnswerType is AnswerType.Correct
                ? new AnswerModel($"Answer: {answer.Correct}")
                : new AnswerModel($"Error: {answer.Wrong}");
            return View(model);
        }
    }
}