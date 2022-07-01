using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Models.Entites;

namespace Web.Services.Product
{
    public class Read : IRequest<IEnumerable<Products>>
    {

        public class Handler : IRequestHandler<Read, IEnumerable<Products>>
        {
            private readonly SalesDbContext _context;

            public Handler(SalesDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Products>> Handle(Read request, CancellationToken cancellationToken)
            {
                return await _context.Set<Products>()
                    .Include(e => e.Brands)
                    .Include(e => e.Categories)
                    .OrderBy(e => e.ProductId)
                    .AsNoTracking()
                    .ToListAsync(); ;
            }
        }
    }
}
