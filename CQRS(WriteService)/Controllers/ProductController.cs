using CQRS.CQRSWriteServive.Commands.Request;
using CQRS.CQRSWriteServive.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator; 
        }    

        [HttpPost]
        [Route("AddNewProductAsync")]
        public async Task<CreateProductCommandResponse> AddNewProduct(CreateProductCommandRequest createProductCommandRequest) 
        {
            return await _mediator.Send(createProductCommandRequest);
        }

        [HttpDelete]
        [Route("DeleteProductById")]
        public async Task<DeleteProductCommandResponse> DeleteProductAsync(DeleteProductCommandRequest deleteProductCommandRequest) 
        {
            return await _mediator.Send(deleteProductCommandRequest);
        }

        [HttpPut]
        [Route("UpdateProductAsync")]
        public async Task<UpdateProductCommandResponse> UpdateProductAsync(UpdateProductCommandRequest updateProductCommandRequest) 
        {
            return await _mediator.Send(updateProductCommandRequest);
        }
        
    }
}
