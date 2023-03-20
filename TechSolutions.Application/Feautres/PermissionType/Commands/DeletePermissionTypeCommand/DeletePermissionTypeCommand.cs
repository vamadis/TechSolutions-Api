using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TechSolutions.Application.Feautres.Permission.Commands.DeletePermissionCommand;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Feautres.PermissionType.Commands.DeletePermissionTypeCommand
{
    public class DeletePermissionTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePermissionTypeCommandHandler : IRequestHandler<DeletePermissionTypeCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TipoPermiso> _repositoryAsync;
        public DeletePermissionTypeCommandHandler(IRepositoryAsync<TipoPermiso> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeletePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            var permission = await _repositoryAsync.GetByIdAsync(request.Id);

            if (permission == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(permission);

                return new Response<int>(permission.Id);
            }
        }
    }
}
