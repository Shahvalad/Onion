using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Exceptions
{
    public class ProductAlreadyExistsException : Exception, IServiceException
    {
        HttpStatusCode IServiceException.StatusCode => HttpStatusCode.Conflict;

        string IServiceException.Message => "Product with this name already exists!";
    }
}
