using Application.Features.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class StudentsMVCController : Controller //Normal Controller
    {
        private IMediator mediator;

        public StudentsMVCController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var students = await mediator.Send(new GetAllStudentQuery());
            return View(students);
        }
    }
}
