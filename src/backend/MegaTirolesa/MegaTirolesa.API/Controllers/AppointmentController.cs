using MegaTirolesa.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace MegaTirolesa.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
