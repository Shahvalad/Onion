using MediatR;
using Onion.Application.Exceptions;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.ProductRepository.GetBy(r=>r.Name == request.name) is not null)
            {
                throw new ProductAlreadyExistsException();
            }

            var product = new Onion.Domain.Entities.Product()
            {
                Name = request.name,
                Price = request.price,
                Quantity = request.quantity,
            };

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.Save();

            return new CreateProductCommandResponse();
        }
    }
}
