using System;

namespace OOP004Exceptions
{
    class IllegalDigitException : Exception
    {
        public IllegalDigitException()
        {
        }
        public IllegalDigitException(string message) : base(message)
        {
        }
        public IllegalDigitException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

