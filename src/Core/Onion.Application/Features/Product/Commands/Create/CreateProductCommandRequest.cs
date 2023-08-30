using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Commands.Create
{
    public record CreateProductCommandRequest(string name, int price, int quantity) : IRequest<CreateProductCommandResponse>;
}
