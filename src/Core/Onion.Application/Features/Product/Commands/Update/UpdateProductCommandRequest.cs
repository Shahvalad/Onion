using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Commands.Update
{
    public record UpdateProductCommandRequest(string name, string newName, decimal newPrice, int newQuantity) : IRequest<UpdateProductCommandResponse>;
}
