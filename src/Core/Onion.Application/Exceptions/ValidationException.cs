using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : this("Invalid input!")
        {
        }

        public ValidationException(string message) : base(message) 
        {
        }

        public ValidationException(Exception ex) : this(ex.Message) 
        {

        }
    }
}
