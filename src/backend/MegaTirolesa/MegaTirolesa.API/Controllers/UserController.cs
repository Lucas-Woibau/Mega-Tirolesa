using MegaTirolesa.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace MegaTirolesa.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
