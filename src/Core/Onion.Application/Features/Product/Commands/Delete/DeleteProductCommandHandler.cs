using MediatR;
using Onion.Application.Exceptions;
using Onion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.ProductRepository.GetBy(p=>p.Name == request.name) is null)
            {
                throw new ProductDoesNotExistsException();
            }

            var existingProduct = await _unitOfWork.ProductRepository.GetBy(p => p.Name == request.name);

            _unitOfWork.ProductRepository.DeleteAsync(existingProduct);

            await _unitOfWork.Save();

            return new DeleteProductCommandResponse();
        }
    }
}
