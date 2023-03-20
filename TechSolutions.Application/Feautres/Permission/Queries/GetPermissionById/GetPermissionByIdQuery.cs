using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;

namespace TechSolutions.Application.Feautres.Permission.Queries.GetPermissionById
{
    public class GetPermissionByIdQuery : IRequest<Response<PermisoDto>>
    {
        public int Id  { get; set; }

        public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, Response<PermisoDto>>
        {
            private readonly IPermissionRepository _permissionRepository;
            private readonly IMapper _mapper;
            public GetPermissionByIdQueryHandler(IPermissionRepository permissionRepository, IMapper mapper)
            {
                _permissionRepository = permissionRepository;
                _mapper = mapper;
            }

            public async Task<Response<PermisoDto>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
            {
                var permission = await _permissionRepository.PermissionById(request.Id);
                if (permission == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
                else
                {
                    return permission;
                }
            }
        }
    }
}
