using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos.RequestDto;
using TechSolutions.Application.Interfaces;

namespace TechSolutions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        //GET all api/<Endpoint>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _permissionRepository.listPermissions());
        }

        //GET byId api/<Endpoint>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _permissionRepository.PermissionById(id));
        }

        //POST api/<Endpoint>
        [HttpPost]
        public async Task<IActionResult> Post(PermissionRequestDto requestDto)
        {
            return Ok(await _permissionRepository.AddPermission(requestDto));
        }

        //PUT api/<Endpoint>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PermissionRequestDto requestDto)
        {
            if (id != requestDto.Id)
                return BadRequest();

            return Ok(await _permissionRepository.UpdatePermission(id,requestDto));
        }

        //DELETE api/<Endpoint>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _permissionRepository.DeletePermission(id));
        }
    }
}
