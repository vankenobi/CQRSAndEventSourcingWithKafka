using CQRS.CQRSWriteServive.Commands.Request;
using CQRS.CQRSWriteServive.Commands.Response;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Model;
using CQRS_WriteService_.EventSourcing;
using CQRS_WriteService_.EventSourcing.EventResponse;
using MediatR;
using System.Data.Entity;

namespace CQRS.CQRS.Handlers.Command_Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly PsqlContext _context;
        private readonly IEvent _event;

        public UpdateProductCommandHandler(PsqlContext context, IEvent eve)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _event = eve;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

                if (product == null)
                    return new UpdateProductCommandResponse() { IsSuccess = false };

                product.Id = request.Id;
                product.Name = request.Name;
                product.Price = request.Price;
                product.Quantity = request.Quantity;

                _context.Products.Update(product);
                await _context.SaveChangesAsync(cancellationToken);

                _event.Updated(new ProductEvent() { CrudType = "Update", Product = product },"product");

                return new UpdateProductCommandResponse() { IsSuccess = true };
            }
            catch (Exception)
            {
                return new UpdateProductCommandResponse() { IsSuccess = false };
            }
            

        }
    }
}
