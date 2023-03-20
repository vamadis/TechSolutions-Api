using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Wrappers;

namespace TechSolutions.Application.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Response<IEnumerable<PermisoDto>>> listPermissions();
        Task<Response<PermisoDto>> PermissionById(int Id);
    }
}
