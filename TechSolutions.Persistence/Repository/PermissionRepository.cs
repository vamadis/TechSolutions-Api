using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSolutions.Application.Behaviours;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Dtos.RequestDto;
using TechSolutions.Application.Exceptions;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;
using TechSolutions.Persistence.Contexts;

namespace TechSolutions.Persistence.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IRepositoryAsync<Permiso> _repositoryAsync;
        private readonly TechSolutionsDbContext _dbContext;
        private readonly PermissionValidator _validationRules;
        private readonly IMapper _mapper;
        public PermissionRepository(TechSolutionsDbContext dbContext, IMapper mapper,
            PermissionValidator validationRules, IRepositoryAsync<Permiso> repositoryAsync)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validationRules = validationRules;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<IEnumerable<PermissionDto>>> listPermissions()
        {
            var permissions = new Response<IEnumerable<PermissionDto>>();
             permissions.Data = await _dbContext.Permisos.Include(x =>x.TipoPermisoNavigation).Select(x => new PermissionDto
             {
                  Id = x.Id,
                  NombreEmpleado = x.NombreEmpleado,
                  ApellidosEmpleado = x.ApellidosEmpleado,
                  FechaPermiso = x.FechaPermiso,
                  PermisoDescripcion = x.TipoPermisoNavigation.Descripcion,
                  TipoPermiso = x.TipoPermiso

            }).ToListAsync();
            return permissions;
        }

        public async Task<Permiso> PermissionById(int Id)
        {
            var permission = new Permiso();
            permission = await _repositoryAsync.GetByIdAsync(Id);
            return permission;
        }

        public async Task<Response<int>> AddPermission(PermissionRequestDto requestDto)
        {
            var result = _validationRules.Validate(requestDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var newPermission = _mapper.Map<Permiso>(requestDto);

            var data = await _repositoryAsync.AddAsync(newPermission);

            return new Response<int>(data.Id);
        }

        public async Task<Response<int>> UpdatePermission(int Id,PermissionRequestDto requestDto)
        {

            var result = _validationRules.Validate(requestDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var permission = await PermissionById(Id);

            if (permission == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {Id}");
            }
            else
            {
                permission.NombreEmpleado = requestDto.NombreEmpleado;
                permission.ApellidosEmpleado = requestDto.ApellidosEmpleado;
                permission.TipoPermiso = requestDto.TipoPermiso;
                permission.FechaPermiso = requestDto.FechaPermiso;

                await _repositoryAsync.UpdateAsync(permission);

                return new Response<int>(permission.Id);
            }
        }

        public async Task<Response<int>> DeletePermission(int Id)
        {
            var permission = await PermissionById(Id);

            if (permission == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(permission);
                return new Response<int>(permission.Id);
            }
        }
    }
}
