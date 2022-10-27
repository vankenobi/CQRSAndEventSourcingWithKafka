using CQRS.CQRS.Commands.Request;
using CQRS.CQRS.Commands.Response;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Model;
using CQRS_WriteService_.EventSourcing;
using MediatR;

namespace CQRS.CQRS.Handlers.Command_Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IEvent _event;
        private readonly PsqlContext _context;

        public CreateProductCommandHandler(PsqlContext context,IEvent eve)
        {
            _context = context;
            _event = eve;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            // Set a new guid
            var id = Guid.NewGuid();
            var newProduct = new Product
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.UtcNow,
            };

            await _context.Products.AddAsync(newProduct, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            _event.Created(newProduct,"product"); // sending event 

            return new CreateProductCommandResponse
            {
                Id = id,
                IsSuccess = true
            };
        }
    }
}
