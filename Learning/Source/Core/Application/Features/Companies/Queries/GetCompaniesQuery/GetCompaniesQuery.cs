using Application.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.GetCompaniesQuery
{
    public class GetCompaniesQuery:IRequest<IList<CompanyDto>>
    {

    }
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IList<CompanyDto>>
    {
        private readonly IApplicationDbContext _context;
        //private readonly IMapper _mapper; //Need Package AutoMapper
        public GetCompaniesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IList<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
