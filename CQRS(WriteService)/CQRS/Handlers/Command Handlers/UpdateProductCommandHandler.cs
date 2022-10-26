using CQRS.CQRS.Commands.Request;
using CQRS.CQRS.Commands.Response;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Model;
using MediatR;
using System.Data.Entity;

namespace CQRS.CQRS.Handlers.Command_Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly PsqlContext _context;
        public UpdateProductCommandHandler(PsqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var hasEntity = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();

                if (hasEntity != null)
                {

                    hasEntity.Id = request.Id;
                    hasEntity.Name = request.Name;
                    hasEntity.Price = request.Price;
                    hasEntity.Quantity = request.Quantity;
                   
                    _context.Products.Update(hasEntity);

                    await _context.SaveChangesAsync(cancellationToken);

                    return new UpdateProductCommandResponse() { IsSuccess = true };
                }

                else
                {
                    return new UpdateProductCommandResponse() { IsSuccess = false };
                }

                return new UpdateProductCommandResponse() { IsSuccess = false };
            }
            catch (Exception)
            {
                return new UpdateProductCommandResponse() { IsSuccess = false };
            }
            

        }
    }
}
