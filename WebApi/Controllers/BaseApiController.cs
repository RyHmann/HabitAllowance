using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => this.mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
