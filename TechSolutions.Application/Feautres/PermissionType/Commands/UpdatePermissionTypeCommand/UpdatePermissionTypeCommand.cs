using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Feautres.PermissionType.Commands.UpdatePermissionTypeCommand
{
    public class UpdatePermissionTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class UpdatePermissionTypeCommandHandler : IRequestHandler<UpdatePermissionTypeCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TipoPermiso> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdatePermissionTypeCommandHandler(IRepositoryAsync<TipoPermiso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdatePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            var permissionType = await _repositoryAsync.GetByIdAsync(request.Id);

            if (permissionType == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                permissionType.Descripcion = request.Descripcion;

                await _repositoryAsync.UpdateAsync(permissionType);

                return new Response<int>(permissionType.Id);
            }
        }
    }
}
