using MediatR;
using Web.Models;
using Web.Models.Entites;

namespace Web.Services.Product
{
    public class Delete
    {
        public class DeleteResult
        {
            public int ProductId { get; set; }
            public string Messages { get; set; }
        }

        public class Command : IRequest<DeleteResult>
        {
            public int ProductId { get; set; }
            public uint? RowVersion { get; set; }
        }

        public class Handler : IRequestHandler<Command, DeleteResult>
        {
            private readonly SalesDbContext _context;
            public Handler(SalesDbContext context)
            {
                _context = context;
            }

            public async Task<DeleteResult> Handle(Command request, CancellationToken cancellationToken)
            {
                Products row = new Products()
                {
                    ProductId = request.ProductId
                };
                _context.Entry(row).Property("RowVersion").OriginalValue = request.RowVersion;
                _context.Set<Products>().Remove(row);
                await _context.SaveChangesAsync(cancellationToken);
                return new DeleteResult
                {
                    ProductId = request.ProductId,
                    Messages    = "Delete Completed"
                };
            }
        }
    }
}
