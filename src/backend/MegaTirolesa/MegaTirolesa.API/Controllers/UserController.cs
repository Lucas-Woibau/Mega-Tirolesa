using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Commands.AppointmentCommands.CreateAppointment;
using MegaTirolesa.Application.Commands.UserCommands.CreateUser;
using MegaTirolesa.Application.Commands.UserCommands.DeleteUser;
using MegaTirolesa.Application.Commands.UserCommands.UpdateUser;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Models;
using MegaTirolesa.Application.Queries.UserQueries.GetAllUsersQuery;
using MegaTirolesa.Application.Queries.UserQueries.GetUserByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace MegaTirolesa.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();

            var response = await _mediator
                .DispatchAsync<GetAllUsersQuery, ResultViewModel<List<UserItemViewModel>>>(query);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);

            var response = await _mediator
                .DispatchAsync<GetUserByIdQuery, ResultViewModel<Guid>>(query);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator
                .DispatchAsync<CreateUserCommand, ResultViewModel<Guid>>(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await _mediator
                .DispatchAsync<UpdateUserCommand, ResultViewModel>(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);

            var response = await _mediator
                .DispatchAsync<DeleteUserCommand, ResultViewModel>(command);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
    }
}
