using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Feautres.PermissionType.Queries.GetAllPermissionTypes
{
    public class GetAllPermissionTypesQuery : IRequest<Response<List<TipoPermisoDto>>>
    {
    }

    public class GetAllPermissionTypesQueryHandler : IRequestHandler<GetAllPermissionTypesQuery, Response<List<TipoPermisoDto>>>
    {
        private readonly IRepositoryAsync<TipoPermiso> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetAllPermissionTypesQueryHandler(IRepositoryAsync<TipoPermiso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<List<TipoPermisoDto>>> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            var listPermissionTypes = await _repositoryAsync.ListAsync();
            var permissionTypesDto = _mapper.Map<List<TipoPermisoDto>>(listPermissionTypes);
            return new Response<List<TipoPermisoDto>>(permissionTypesDto);
        }
    }
}
