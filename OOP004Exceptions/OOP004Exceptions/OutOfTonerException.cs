using System;

namespace OOP004Exceptions
{
    class OutOfTonerException : Exception
    {
        public OutOfTonerException()
        {
        }
        public OutOfTonerException(string message) : base(message)
        {
        }
        public OutOfTonerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

