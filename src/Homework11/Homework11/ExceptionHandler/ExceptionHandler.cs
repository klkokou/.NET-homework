using System;
using Homework11.Interfaces;
using Microsoft.Extensions.Logging;

namespace Homework11.ExceptionHandler
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void HandleException<T>(T exception) where T : Exception
        {
            this.Handle((dynamic)exception);
        }

        private void Handle(ArgumentException exception)
        {
            _logger.LogError(exception.Message);
        }

        private void Handle(InvalidSyntaxException exception)
        {
            _logger.LogError(exception.Message);
        }

        private void Handle(InvalidSymbolException exception)
        {
            _logger.LogError(exception.Message);
        }
    }

    public class InvalidSymbolException : Exception
    {
        public InvalidSymbolException(string message) : base(message)
        {
        }
    }

    public class InvalidSyntaxException : Exception
    {
        public InvalidSyntaxException(string message) : base(message)
        {
        }
    }
    
}