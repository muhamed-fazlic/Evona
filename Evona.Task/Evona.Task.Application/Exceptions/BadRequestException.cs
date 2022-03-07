using System;

namespace Evona.Task.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message):base(message)
        {

        }
    }
}
