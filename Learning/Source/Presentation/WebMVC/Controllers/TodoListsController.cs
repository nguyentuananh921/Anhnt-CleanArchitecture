using Application.Features.TodoLists.Queries.GetTodoListsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Controllers.Common;

namespace WebMVC.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class TodoListsController : BaseController<TodoListsController>
    {
        //[HttpGet]
        //public async Task<ActionResult<GetTodoListsVM>> Get()
        //{
        //    //return await Mediator.Send(new GetTodoListsQuery());
        //}
    }
}
