using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Commands.AppointmentCommands.CreateAppointment;
using MegaTirolesa.Application.Commands.AppointmentCommands.DeleteAppointment;
using MegaTirolesa.Application.Commands.AppointmentCommands.UpdateAppointment;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Models;
using MegaTirolesa.Application.Queries.AppointmentQueries.GetAllAppointmentQuery;
using MegaTirolesa.Application.Queries.AppointmentQueries.GetAppointmentByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace MegaTirolesa.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAppointmentsQuery();

            var response = await _mediator
                .DispatchAsync<GetAllAppointmentsQuery, ResultViewModel<List<AppointmentItemViewModel>>>(query);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetAppointmentByIdQuery(id);

            var response = await _mediator
                .DispatchAsync<GetAppointmentByIdQuery, ResultViewModel<Guid>>(query);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommand command)
        {
            var result = await _mediator
                .DispatchAsync<CreateAppointmentCommand, ResultViewModel<Guid>>(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateAppointmentCommand command)
        {
            var result = await _mediator
                .DispatchAsync<UpdateAppointmentCommand, ResultViewModel>(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAppointmentCommand(id);

            var response = await _mediator
                .DispatchAsync<DeleteAppointmentCommand, ResultViewModel>(command);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
    }
}
