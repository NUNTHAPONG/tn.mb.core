using MediatR;
using Web.Models;
using Web.Models.Entities;

namespace Web.Services.Customer
{
    public class Create
    {
        public class CreateResult
        {
            public int CustomerId { get; set; }
            public string Messages { get; set; }
        }

        public class Command : Customers, IRequest<CreateResult>
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
                if(request.CustomerId == 0)
                {
                    var genCustId = _context.Set<Customers>().Max(c => c.CustomerId);
                    request.CustomerId = genCustId + 1;
                }
                _context.Set<Customers>().Add(request);
                await _context.SaveChangesAsync(cancellationToken);

                return new CreateResult
                {
                    CustomerId = request.CustomerId,
                    Messages = "Insert Completed"
                };
            }
        }
    }
}
