using MediatR;
using Web.Models;
using Web.Models.Entites;

namespace Web.Services.Customer
{
    public class Update
    {
        public class UpdateResult
        {
            public int CustomerId { get; set; }
            public string Messages { get; set; }
        }

        public class Command : Customers, IRequest<UpdateResult>
        {

        }

        public class Handler : IRequestHandler<Command, UpdateResult>
        {
            private readonly SalesDbContext _context;
            public Handler(SalesDbContext context)
            {
                _context = context;
            }
            public async Task<UpdateResult> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Set<Customers>().Update(request);
                await _context.SaveChangesAsync(cancellationToken);
                return new UpdateResult
                {
                    CustomerId  = request.CustomerId,
                    Messages    = "Update Completed"
                };
            }
        }
    }
}
