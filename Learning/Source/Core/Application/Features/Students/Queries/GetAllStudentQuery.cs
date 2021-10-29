using Application.Interfaces.Contexts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Student>>
    {
    }
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
    {
        private readonly IApplicationDbContext context;
        public GetAllStudentQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery query, CancellationToken cancellationToken)
        {
            var studentList = await context.Students.ToListAsync();
            if (studentList == null)
            {
                return null;
            }
            return studentList.AsReadOnly();
        }
    }
}
