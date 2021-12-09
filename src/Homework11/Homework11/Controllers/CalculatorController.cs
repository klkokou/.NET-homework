using System;
using Homework11.Calculator;
using Homework11.Interfaces;
using Homework11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator calculator;
        private readonly IExceptionHandler exceptionHandler;

        public CalculatorController(ICalculator calculator, IExceptionHandler exceptionHandler)
        {
            this.calculator = calculator;
            this.exceptionHandler = exceptionHandler;
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            AnswerModel answerModel;
            try
            {
                var answer = calculator.Calculate(expression);
                answerModel = new AnswerModel($"Answer: {answer}");
            }
            catch (Exception exception)
            {
                exceptionHandler.HandleException(exception);
                answerModel = new AnswerModel($"Error: {exception.Message}");
            }

            return View(answerModel);
        }
    }
}