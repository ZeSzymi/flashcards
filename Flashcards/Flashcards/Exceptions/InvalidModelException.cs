using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException()
        {
        }

        public InvalidModelException(string message) : base(message)
        {
        }

        public InvalidModelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
