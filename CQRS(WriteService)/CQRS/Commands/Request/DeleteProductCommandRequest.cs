using CQRS.CQRS.Commands.Response;
using MediatR;

namespace CQRS.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
