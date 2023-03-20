using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechSolutions.Application.Feautres.Permission.Commands.CreatePermissionCommand;
using TechSolutions.Application.Feautres.Permission.Commands.DeletePermissionCommand;
using TechSolutions.Application.Feautres.Permission.Commands.UpdatePermissionCommand;
using TechSolutions.Application.Feautres.Permission.Queries.GetAllPermissions;
using TechSolutions.Application.Feautres.Permission.Queries.GetPermissionById;

namespace TechSolutions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET all api/<endpoin>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllPermissionsQuery{}));
        }

        //GET byId api/<endpoin>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetPermissionByIdQuery { Id = id }));
        }

        //POST api/<endpoin>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePermissionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //PUT api/<endpoin>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePermissionCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        //DELETE api/<endpoin>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePermissionCommand { Id = id }));
        }
    }
}
