using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Contexts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries
{
    public class GetAllCarsQuery:IRequest<IEnumerable<Car>> {}
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {

        private readonly IApplicationDbContext context;

        public GetAllCarsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var carsList = await context.Cars.ToListAsync(cancellationToken);
            if (carsList == null)
            {
                return null;
            }
            return carsList.AsReadOnly();
        }
    }
}
