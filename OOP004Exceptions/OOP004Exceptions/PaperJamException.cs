using System;

namespace OOP004Exceptions
{
    class PaperJamException : Exception
    {
        public PaperJamException()
        {
        }
        public PaperJamException(string message) : base(message)
        {
        }
        public PaperJamException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

