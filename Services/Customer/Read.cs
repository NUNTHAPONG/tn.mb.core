﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Models.Entites;

namespace Web.Services.Customer
{
    public class Read 
    {
        public class Query : IRequest<IEnumerable<Customers>>
        {
            public string? Keyword { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Customers>>
        {
            private readonly SalesDbContext _context;

            public Handler(SalesDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Customers>> Handle(Query request, CancellationToken cancellationToken)
            {
                if(!String.IsNullOrWhiteSpace(request.Keyword))
                {
                    string likeParams = "%" + request.Keyword + "%";
                    return await _context.Set<Customers>()
                        .Where(e => EF.Functions.ILike(string.Concat(e.FirstName, e.LastName, e.Email, e.CustomerId.ToString()), likeParams))
                        .OrderBy(e => e.CustomerId)
                        .AsNoTracking()
                        .ToListAsync();
                }
                else
                {
                    return await _context.Set<Customers>()
                    .OrderBy(e => e.CustomerId)
                    .AsNoTracking()
                    .ToListAsync();
                }
                
            }
        }
    }
}
