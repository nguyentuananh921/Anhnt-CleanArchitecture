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
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IApplicationDbContext context;
        public GetStudentByIdQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            var student = await context.Students.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
            if (student == null) return null;
            return student;
        }
    }
}
