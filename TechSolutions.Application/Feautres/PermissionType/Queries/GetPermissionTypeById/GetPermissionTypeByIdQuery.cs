using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Feautres.PermissionType.Queries.GetPermissionTypeById
{
    public class GetPermissionTypeByIdQuery : IRequest<Response<TipoPermisoDto>>
    {
        public int Id { get; set; }

        public class GetPermissionTypeByIdQueryHandler : IRequestHandler<GetPermissionTypeByIdQuery, Response<TipoPermisoDto>>
        {
            private readonly IRepositoryAsync<TipoPermiso> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetPermissionTypeByIdQueryHandler(IRepositoryAsync<TipoPermiso> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<TipoPermisoDto>> Handle(GetPermissionTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var permissionType = await _repositoryAsync.GetByIdAsync(request.Id);
                if (permissionType == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<TipoPermisoDto>(permissionType);
                    return new Response<TipoPermisoDto>(dto);
                }
            }
        }
    }
}
