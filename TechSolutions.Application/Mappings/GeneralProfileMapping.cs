using AutoMapper;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Feautres.Permission.Commands.CreatePermissionCommand;
using TechSolutions.Application.Feautres.PermissionType.Commands.CreatePermissionTypeCommand;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Mappings
{
    public class GeneralProfileMapping : Profile
    {
        public GeneralProfileMapping()
        {
            #region Dtos
            CreateMap<Permiso, PermisoDto>();
            CreateMap<TipoPermiso, TipoPermisoDto>();
            #endregion

            #region Commands
            CreateMap<CreatePermissionCommand, Permiso>();
            CreateMap<CreatePermissionTypeCommand, TipoPermiso>();
            #endregion
        }
    }
}
