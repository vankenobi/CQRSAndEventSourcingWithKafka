using CQRS.CQRS.Queries.Request;
using CQRS.CQRS.Queries.Response;
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

        [HttpGet]
        [Route("GetAllProductsAsync")]
        public async Task<List<GetAllProductQueryResponse>> GetAllProducts() 
        {
            var query = new GetAllProductQueryRequest();
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("GetProductByIdAsync")]
        public async Task<GetProductByIdQueryResponse> GetProductByIdAsync(GetProductByIdQueryRequest getProductByIdQueryRequest) 
        {
            return await _mediator.Send(getProductByIdQueryRequest);
        }

    }
}
