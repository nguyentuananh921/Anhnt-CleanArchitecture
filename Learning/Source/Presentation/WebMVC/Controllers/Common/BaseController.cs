using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace WebMVC.Controllers.Common
{
    public abstract class BaseController<T> : Controller
    {
        //private IMediator _mediatorInstance;
        private ISender _mediator;
        private ILogger<T> _loggerInstance;
        //private IViewRenderService _viewRenderInstance;
        //private IMapper _mapperInstance;
        //private INotyfService _notifyInstance;

        //protected INotyfService _notify => _notifyInstance ??= HttpContext.RequestServices.GetService<INotyfService>();

        #region ISender
        /// <summary>
        /// Require using Microsoft.Extensions.DependencyInjection;
        /// </summary>
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        #endregion


        //protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        //protected IViewRenderService _viewRenderer => _viewRenderInstance ??= HttpContext.RequestServices.GetService<IViewRenderService>();
        //protected IMapper _mapper => _mapperInstance ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
