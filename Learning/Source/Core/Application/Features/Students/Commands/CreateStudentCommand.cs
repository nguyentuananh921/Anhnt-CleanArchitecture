﻿using Application.Interfaces.Contexts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Standard { get; set; }
        public int Rank { get; set; }
    }
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IApplicationDbContext context;
        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Student();
            student.Name = command.Name;
            student.Standard = command.Standard;
            student.Rank = command.Rank;

            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student.Id;
        }
    }
}
