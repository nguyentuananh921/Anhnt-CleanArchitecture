using Application.Interfaces.Contexts;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Queries.GetTodoListsQuery
{    
    public class GetTodoListsQuery: IRequest<IEnumerable<TodoList>>
    {

    }
    //public class GetTodoListsHandler :IRequestHandler<GetTodoListsQuery, TodoList>
    //{
    //    private readonly IApplicationDbContext _context;

    //    public GetTodoListsHandler(IApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<TodoList> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
    //    {
    //        return await _context.TodoLists().ToListAsync<TodoList>();
            
    //    }
    //}
}
