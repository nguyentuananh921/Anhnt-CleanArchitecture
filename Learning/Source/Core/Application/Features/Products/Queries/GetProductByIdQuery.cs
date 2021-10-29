using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            //var Id = request.Id;
            var product = _context.Products.Where(a => a.Id == request.Id).FirstOrDefault();
            if (product == null) return null;
            return product;
        }
    }

}
