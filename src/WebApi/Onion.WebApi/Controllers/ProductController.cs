using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Dtos;
using Onion.Application.Features.Product.Commands.Create;
using Onion.Application.Features.Product.Commands.Delete;
using Onion.Application.Features.Product.Commands.Update;
using Onion.Application.Features.Product.Queries.GetAll;
using Onion.Application.Features.Product.Queries.GetById;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQueryRequest();

            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> GetByName(GetByNameQueryRequest request)
        {
            var query = new GetByNameQueryRequest(request.name);

            var product = await _mediator.Send(query);

            return Ok(product);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            var command = new CreateProductCommandRequest(request.name, request.price, request.quantity);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            var command = new UpdateProductCommandRequest(request.name, request.newName, request.newPrice, request.newQuantity);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
        {
            var command = new DeleteProductCommandRequest(request.name);

            await _mediator.Send(command);

            return Ok();
        }

    }
}
