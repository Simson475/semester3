using System;

namespace OOP004Exceptions
{

    class NoSuchDigitException : Exception
    {
        public NoSuchDigitException()
        {
        }
        public NoSuchDigitException(string message) : base(message)
        {
        }
        public NoSuchDigitException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

