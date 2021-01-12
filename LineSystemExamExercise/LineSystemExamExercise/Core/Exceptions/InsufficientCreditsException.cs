using System;
using System.Runtime.Serialization;

namespace Core
{
    public class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException()
        {
        }

        public InsufficientCreditsException(string message) : base(message)
        {
        }
        public InsufficientCreditsException(string message, User user, Product product) : base(message)
        {
            Product = product;
            User = user;
        }
        public InsufficientCreditsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}