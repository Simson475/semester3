using System;
using System.Runtime.Serialization;

namespace Core
{
    public class NoUserFoundException : Exception
    {
        public NoUserFoundException()
        {
        }

        public NoUserFoundException(string message) : base(message)
        {
        }

        public NoUserFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}