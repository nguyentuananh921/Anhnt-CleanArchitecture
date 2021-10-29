using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {

        //https://jimmybogard.com/mediatr-9-0-released/

        private ISender _mediator;

        //Require using Microsoft.Extensions.DependencyInjection;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
