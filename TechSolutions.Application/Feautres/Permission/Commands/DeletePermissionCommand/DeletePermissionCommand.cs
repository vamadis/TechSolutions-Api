using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;
using AutoMapper;

namespace TechSolutions.Application.Feautres.Permission.Commands.DeletePermissionCommand
{
    public class DeletePermissionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Permiso> _repositoryAsync;
        private readonly IMapper _mapper;
        public DeletePermissionCommandHandler(IRepositoryAsync<Permiso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
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
