using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Queries.GetById
{
    public record GetByNameQueryRequest(string name) : IRequest<GetByNameQueryResponse>;
}
