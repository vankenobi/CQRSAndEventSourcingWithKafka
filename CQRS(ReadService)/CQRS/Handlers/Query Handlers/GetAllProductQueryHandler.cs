using CQRS.CQRS.Queries.Request;
using CQRS.CQRS.Queries.Response;
using CQRS.Infrastructure.Context;
using MediatR;

namespace CQRS.CQRS.Handlers.Query_Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,List<GetAllProductQueryResponse>>
    {
        private readonly PsqlContext _context;

        public GetAllProductQueryHandler(PsqlContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _context.Products.Select(product => new GetAllProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            });
            
            return result.ToList();
        }
    }
}
