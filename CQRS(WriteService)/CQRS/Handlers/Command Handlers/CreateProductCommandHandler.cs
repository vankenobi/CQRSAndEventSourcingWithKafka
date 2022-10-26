using CQRS.CQRS.Commands.Request;
using CQRS.CQRS.Commands.Response;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Model;
using MediatR;

namespace CQRS.CQRS.Handlers.Command_Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly PsqlContext _context;
        public CreateProductCommandHandler(PsqlContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            // Set a new guid
            var id = Guid.NewGuid();

            await _context.Products.AddAsync(new Product
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.UtcNow,
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductCommandResponse
            {
                Id = id,
                IsSuccess = true
            };
        }
    }
}
