using CQRS.CQRS.Queries.Response;
using MediatR;

namespace CQRS.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
        
    }
}
