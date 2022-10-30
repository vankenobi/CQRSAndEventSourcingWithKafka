using CQRS.CQRSWriteServive.Commands.Response;
using MediatR;

namespace CQRS.CQRSWriteServive.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
