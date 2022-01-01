using System;

namespace Homework11.Interfaces
{
    public interface IExceptionHandler
    {
        public void HandleException<T>(T exception) where T : Exception;
    }
}