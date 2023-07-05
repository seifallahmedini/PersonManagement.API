using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Application.Exceptions
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException() { }

        public InvalidAgeException(string message) : base(message) { }

        public InvalidAgeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
