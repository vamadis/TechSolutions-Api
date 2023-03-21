using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Interfaces
{
    public interface IPermissionTypeRepository
    {
        Task<Response<List<PermissionTypeDto>>> listPermissionTypes();
        Task<TipoPermiso> PermissionTypeById(int Id);
        Task<Response<int>> AddPermissionType(PermissionTypeDto requestDto);
        Task<Response<int>> UpdatePermissionType(int Id, PermissionTypeDto requestDto);
        Task<Response<int>> DeletePermissionType(int Id);
    }
}
