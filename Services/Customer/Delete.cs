using MediatR;
using Web.Models;
using Web.Models.Entities;

namespace Web.Services.Customer
{
    public class Delete
    {
        public class DeleteResult
        {
            public int CustomerId { get; set; }
            public string Messages { get; set; }
        }

        public class Command : IRequest<DeleteResult>
        {
            public int CustomerId { get; set; }
            public uint? RowVersion { get; set; }
        }

        public class Handler : IRequestHandler<Command, DeleteResult>
        {
            private readonly CleanDbContext _context;
            public Handler(CleanDbContext context)
            {
                _context = context;
            }

            public async Task<DeleteResult> Handle(Command request, CancellationToken cancellationToken)
            {
                Customers row = new Customers()
                {
                    CustomerId = request.CustomerId
                };
                _context.Entry(row).Property("RowVersion").OriginalValue = request.RowVersion;
                _context.Set<Customers>().Remove(row);
                await _context.SaveChangesAsync(cancellationToken);
                return new DeleteResult
                {
                    CustomerId  = request.CustomerId,
                    Messages    = "Delete Completed"
                };
            }
        }
    }
}
