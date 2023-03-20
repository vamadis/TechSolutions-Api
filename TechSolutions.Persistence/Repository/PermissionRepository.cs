using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Persistence.Contexts;

namespace TechSolutions.Persistence.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly TechSolutionsDbContext _dbContext;
        public PermissionRepository(TechSolutionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<IEnumerable<PermisoDto>>> listPermissions()
        {
            var permissions = new Response<IEnumerable<PermisoDto>>();
             permissions.Data = await _dbContext.Permisos.Include(x =>x.TipoPermisoNavigation).Select(x => new PermisoDto
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

        public async Task<Response<PermisoDto>> PermissionById(int Id)
        {
            var permission = new Response<PermisoDto>();
             permission.Data = await _dbContext.Permisos.AsNoTracking()
                                                        .Where(x => x.Id == Id)
                                                       .Include(x => x.TipoPermisoNavigation).Select(x => new PermisoDto
                                                        {
                                                          Id = x.Id,
                                                          NombreEmpleado = x.NombreEmpleado,
                                                          ApellidosEmpleado = x.ApellidosEmpleado,
                                                          FechaPermiso = x.FechaPermiso,
                                                          PermisoDescripcion = x.TipoPermisoNavigation.Descripcion,
                                                          TipoPermiso = x.TipoPermiso
                                                       }).FirstOrDefaultAsync();
            return permission;
        }
    }
}
