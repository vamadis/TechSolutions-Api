using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;

namespace TechSolutions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeRepository _permissionType;

        public PermissionTypeController(IPermissionTypeRepository permissionType)
        {
            _permissionType = permissionType;
        }

        //GET all api/<Endpoint>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _permissionType.listPermissionTypes());
        }

        //GET byid api/<Endpoint>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _permissionType.PermissionTypeById(id));
        }

        //POST api/<Endpoint>
        [HttpPost]
        public async Task<IActionResult> Post(PermissionTypeDto typeDto)
        {
            return Ok(await _permissionType.AddPermissionType(typeDto));
        }

        //PUT api/<Endpoint>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PermissionTypeDto  typeDto)
        {
            if (id != typeDto.Id)
                return BadRequest();

            return Ok(await _permissionType.UpdatePermissionType(id,typeDto));
        }

        //DELETE api/<Endpoint>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _permissionType.DeletePermissionType(id));
        }
    }
}
