using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Models.Entites;

namespace Web.Services.Customer
{
    public class Find
    {
        public class Query : IRequest<Customers>
        {
            public int CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Customers>
        {
            private readonly SalesDbContext _context;
            public Handler(SalesDbContext context)
            {
                _context = context;
            }

            public async Task<Customers> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Set<Customers>()
                    .Include(m => m.Orders)
                    .FirstOrDefaultAsync(i => i.CustomerId == request.CustomerId);
            }
        }
    }
}