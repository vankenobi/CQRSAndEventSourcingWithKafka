using CQRS.CQRS.Queries.Request;
using CQRS.CQRS.Queries.Response;
using CQRS.Infrastructure.Context;
using MediatR;
using System.Data.Entity;

namespace CQRS.CQRS.Handlers.Query_Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest,GetProductByIdQueryResponse>
    {
        private readonly PsqlContext _psqlContext; 

        public GetProductByIdQueryHandler(PsqlContext psqlContext)
        {
               _psqlContext = psqlContext;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _psqlContext.Products.FirstOrDefault(x => x.Id == request.Id);
            return new GetProductByIdQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
