using CQRS.CQRSWriteServive.Commands.Request;
using CQRS.CQRSWriteServive.Commands.Response;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Model;
using CQRS_WriteService_.EventSourcing;
using CQRS_WriteService_.EventSourcing.EventResponse;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.CQRS.Handlers.Command_Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly PsqlContext _context;
        private readonly IEvent _event;

        public DeleteProductCommandHandler(PsqlContext context,IEvent eve)
        {
            _context = context;
            _event = eve;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                if (product == null)
                    return new DeleteProductCommandResponse() { IsSuccess = false };
                
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);

                _event.Deleted(new ProductEvent { CrudType = "Delete", Product = product },"product"); // event sending

                return new DeleteProductCommandResponse { IsSuccess = true };
            }
            catch (Exception)
            {
                return new DeleteProductCommandResponse { IsSuccess = false };
            }
            
        }
    }
}
