using System;
using System.Runtime.Serialization;

namespace Core
{
    public class InactiveProductException : Exception
    {
        public InactiveProductException()
        {
        }

        public InactiveProductException(string message) : base(message)
        {
        }

        public InactiveProductException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}