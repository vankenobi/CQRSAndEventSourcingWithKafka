using CQRS.CQRS.Queries.Response;
using MediatR;

namespace CQRS.CQRS.Queries.Request
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
