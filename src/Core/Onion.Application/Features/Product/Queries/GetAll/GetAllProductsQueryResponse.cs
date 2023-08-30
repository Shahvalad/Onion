using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Queries.GetAll
{
    public record GetAllProductsQueryResponse(List<Dtos.ProductDto> products);
}
