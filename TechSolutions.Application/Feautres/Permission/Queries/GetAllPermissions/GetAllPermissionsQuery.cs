using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;

namespace TechSolutions.Application.Feautres.Permission.Queries.GetAllPermissions
{
    public class GetAllPermissionsQuery : IRequest<Response<IEnumerable<PermisoDto>>>
    {
    }

    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, Response<IEnumerable<PermisoDto>>>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public GetAllPermissionsQueryHandler(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<PermisoDto>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var listPermissions = await _permissionRepository.listPermissions();

            return listPermissions;
        }
    }
}
