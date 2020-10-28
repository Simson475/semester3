using System;

namespace OOP004Exceptions
{
    class OutOfPaperException : Exception
    {
        public OutOfPaperException()
        {
        }
        public OutOfPaperException(string message) : base(message)
        {
        }
        public OutOfPaperException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

