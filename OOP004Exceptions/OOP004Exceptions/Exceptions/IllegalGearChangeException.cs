using System;

namespace OOP004Exceptions
{

    class IllegalGearChangeException : Exception
    {
        public IllegalGearChangeException()
        {
        }
        public IllegalGearChangeException(string message) : base(message)
        {
        }
        public IllegalGearChangeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

