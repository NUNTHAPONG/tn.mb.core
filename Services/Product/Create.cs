using MediatR;
using Web.Models;
using Web.Models.Entities;

namespace Web.Services.Product
{
    public class Create
    {
        public class CreateResult
        {
            public int ProductId { get; set; }
            public string Messages { get; set; }
        }

        public class Command : Products, IRequest<CreateResult>
        {
        }

        public class Handler : IRequestHandler<Command, CreateResult>
        {
            private readonly CleanDbContext _context;
            public Handler(CleanDbContext context)
            {
                _context = context;
            }

            public async Task<CreateResult> Handle(Command request, CancellationToken cancellationToken)
            {

                _context.Set<Products>().Add(request);
                await _context.SaveChangesAsync(cancellationToken);

                return new CreateResult
                {
                    ProductId = request.ProductId,
                    Messages = "Insert Completed"
                };
            }
        }
    }
}
