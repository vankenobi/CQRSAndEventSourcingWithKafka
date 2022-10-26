using CQRS.CQRS.Commands.Request;
using CQRS.CQRS.Commands.Response;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Model;
using MediatR;

namespace CQRS.CQRS.Handlers.Command_Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly PsqlContext _context;
        public DeleteProductCommandHandler(PsqlContext context)
        {
            _context = context;        
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Products.Remove(new Product()
                {
                    Id = request.Id,
                });

                await _context.SaveChangesAsync(cancellationToken);
                return new DeleteProductCommandResponse { IsSuccess = true };
            }
            catch (Exception)
            {
                return new DeleteProductCommandResponse { IsSuccess = false };
            }
            
        }
    }
}
