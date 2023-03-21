using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Dtos.RequestDto;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Response<IEnumerable<PermissionDto>>> listPermissions();
        Task<Permiso> PermissionById(int Id);
        Task<Response<int>> AddPermission(PermissionRequestDto requestDto);
        Task<Response<int>> UpdatePermission(int Id, PermissionRequestDto requestDto);
        Task<Response<int>> DeletePermission(int Id);
    }
}
