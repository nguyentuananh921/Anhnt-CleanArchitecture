using Application.Features.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class CarsController : Controller
    {
        private IMediator mediator;

        public CarsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(GetAllCarsQuery query)
        {
            //var carlist = await mediator.Send(new GetAllCarsQuery());
            var carlist = await mediator.Send(query);
            return View(carlist);
        }
    }
}
