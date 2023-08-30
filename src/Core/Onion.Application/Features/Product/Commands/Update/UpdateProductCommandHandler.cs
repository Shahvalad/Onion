using MediatR;
using Onion.Application.Exceptions;
using Onion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.ProductRepository.GetBy(p=>p.Name == request.newName) is not null)
            {
                throw new ProductAlreadyExistsException();
            }

            var existingProduct = await _unitOfWork.ProductRepository.GetBy(p => p.Name == request.name);

            existingProduct.Name = request.newName;
            existingProduct.Price = request.newPrice;
            existingProduct.Quantity= request.newQuantity;

            await _unitOfWork.Save();
            return new UpdateProductCommandResponse();

        }
    }
}
