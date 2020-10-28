using System;

namespace OOP004Exceptions
{
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
        {
        }
        public InsufficientFundsException(string message) : base(message)
        {
        }
        public InsufficientFundsException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
