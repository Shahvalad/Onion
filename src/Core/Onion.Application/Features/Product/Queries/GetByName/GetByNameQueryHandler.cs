using MediatR;
using Onion.Application.Exceptions;
using Onion.Application.Features.Product.Queries.GetById;
using Onion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Queries.GetByName
{
    public class GetByNameQueryHandler : IRequestHandler<GetByNameQueryRequest, GetByNameQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetByNameQueryResponse> Handle(GetByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetBy(p=>p.Name == request.name);
            if (product == null)
            {
                throw new ProductDoesNotExistsException();
            }
            
            return new GetByNameQueryResponse(product.Name, product.Price, product.CreationDate);
        }
    }
}
