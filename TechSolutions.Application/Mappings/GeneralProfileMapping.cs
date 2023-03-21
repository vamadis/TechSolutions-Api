using AutoMapper;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Dtos.RequestDto;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Mappings
{
    public class GeneralProfileMapping : Profile
    {
        public GeneralProfileMapping()
        {
            #region Dtos
            CreateMap<Permiso, PermissionDto>();
            CreateMap<TipoPermiso, PermissionTypeDto>();
            #endregion

            #region Commands
            CreateMap<PermissionRequestDto, Permiso>(); 
            CreateMap<PermissionTypeDto, TipoPermiso>();
            #endregion
        }
    }
}
