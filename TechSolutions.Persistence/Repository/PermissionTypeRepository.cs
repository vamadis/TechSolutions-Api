using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolutions.Application.Behaviours;
using TechSolutions.Application.Dtos.RequestDto;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;
using TechSolutions.Application.Exceptions;

namespace TechSolutions.Persistence.Repository
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly IRepositoryAsync<TipoPermiso> _repositoryAsync;
        private readonly PermissionTypeValidator _validationRules;
        private readonly IMapper _mapper;
        public PermissionTypeRepository(IRepositoryAsync<TipoPermiso> repositoryAsync,
                                        PermissionTypeValidator validationRules, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _validationRules = validationRules;
            _mapper = mapper;
        }

        public async Task<Response<List<PermissionTypeDto>>> listPermissionTypes()
        {
            var listPermissionTypes = await _repositoryAsync.ListAsync();
            var permissionTypesDto = _mapper.Map<List<PermissionTypeDto>>(listPermissionTypes);

            return new Response<List<PermissionTypeDto>>(permissionTypesDto);
        }

        public async Task<TipoPermiso> PermissionTypeById(int Id)
        {
            var permissionType = new TipoPermiso();
            permissionType = await _repositoryAsync.GetByIdAsync(Id);
            return permissionType;
        }

        public async Task<Response<int>> AddPermissionType(PermissionTypeDto requestDto)
        {
            var result = _validationRules.Validate(requestDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var newPermission = _mapper.Map<TipoPermiso>(requestDto);

            var data = await _repositoryAsync.AddAsync(newPermission);

            return new Response<int>(data.Id);
        }

        public async Task<Response<int>> UpdatePermissionType(int Id, PermissionTypeDto requestDto)
        {

            var result = _validationRules.Validate(requestDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var permission = await PermissionTypeById(Id);

            if (permission == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {Id}");
            }
            else
            {
                
                permission.Descripcion = requestDto.Descripcion;

                await _repositoryAsync.UpdateAsync(permission);

                return new Response<int>(permission.Id);
            }
        }

        public async Task<Response<int>> DeletePermissionType(int Id)
        {
            var permission = await PermissionTypeById(Id);

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
