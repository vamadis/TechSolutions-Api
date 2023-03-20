using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechSolutions.Application.Feautres.PermissionType.Commands.CreatePermissionTypeCommand;
using TechSolutions.Application.Feautres.PermissionType.Commands.DeletePermissionTypeCommand;
using TechSolutions.Application.Feautres.PermissionType.Commands.UpdatePermissionTypeCommand;
using TechSolutions.Application.Feautres.PermissionType.Queries.GetAllPermissionTypes;
using TechSolutions.Application.Feautres.PermissionType.Queries.GetPermissionTypeById;

namespace TechSolutions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET all api/<endpoin>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllPermissionTypesQuery {}));
        }

        //GET byid api/<endpoin>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetPermissionTypeByIdQuery { Id = id }));
        }

        //POST api/<endpoin>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePermissionTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //PUT api/<endpoin>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePermissionTypeCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        //DELETE api/<endpoin>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePermissionTypeCommand { Id = id }));
        }
    }
}
