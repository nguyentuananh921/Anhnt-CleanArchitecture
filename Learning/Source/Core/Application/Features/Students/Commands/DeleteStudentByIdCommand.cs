using Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands
{
    public class DeleteStudentByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, int>
    {
        private readonly IApplicationDbContext context;
        public DeleteStudentByIdCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
        {
            var student = await context.Students.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (student == null) return default;
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return student.Id;
        }
    }
}
