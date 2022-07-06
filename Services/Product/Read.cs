using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Models.Entities;

namespace Web.Services.Product
{
    public class Read
    {
        public class Query : IRequest<IEnumerable<Products>>
        {
            public string? Keyword { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Products>>
        {
            private readonly CleanDbContext _context;

            public Handler(CleanDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Products>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!String.IsNullOrWhiteSpace(request.Keyword))
                {
                    string likeParams = "%" + request.Keyword + "%";
                    return await _context.Set<Products>()
                        .Include(e => e.Brands)
                        .Include(e => e.Categories)
                        .Where(e => EF.Functions.ILike(string.Concat(e.ProductName, e.Brands.BrandName, e.Categories.CategoryName), likeParams))
                        .OrderBy(e => e.ProductId)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
                }
                else
                {
                    return await _context.Set<Products>()
                        .Include(e => e.Brands)
                        .Include(e => e.Categories)
                        .OrderBy(e => e.ProductId)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
                }
            }
        }
    }
}
