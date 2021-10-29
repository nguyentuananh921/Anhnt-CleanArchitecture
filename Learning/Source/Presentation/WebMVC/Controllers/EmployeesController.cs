using Application.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private ISender mediator;

        public EmployeesController(ISender mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var emloyees = await mediator.Send(new GetAllEmployeeQuery());

            return View(emloyees);
        }
    }
}
