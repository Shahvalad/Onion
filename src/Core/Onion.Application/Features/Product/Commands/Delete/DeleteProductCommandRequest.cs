using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Commands.Delete
{
    public record DeleteProductCommandRequest(string name) : IRequest<DeleteProductCommandResponse>;
}
