using MediatR;
using Web.Models;
using Web.Models.Entities;

namespace Web.Services.Customer
{
    public class Find
    {
        public class Query : IRequest<Customers>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Customers>
        {
            private readonly CleanDbContext _context;
            public Handler(CleanDbContext context)
            {
                _context = context;
            }

            public async Task<Customers> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Set<Customers>()
                    .FindAsync(request.Id);
            }
        }
    }
}