using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COVIDApplicationView.Controllers
{
        // GET: /<controller>/
        [ApiController]
        [Route("api/[controller]/[action]")]
        public abstract class Base : Controller
        {
            private IMediator _mediator;

            public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        }
}
