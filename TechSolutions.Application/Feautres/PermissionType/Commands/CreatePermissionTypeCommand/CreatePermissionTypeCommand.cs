using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TechSolutions.Application.Feautres.Permission.Commands.CreatePermissionCommand;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Feautres.PermissionType.Commands.CreatePermissionTypeCommand
{
    public class CreatePermissionTypeCommand : IRequest<Response<int>>
    {
        public string Descripcion { get; set; }
    }

    public class CreatePermissionTypeCommandHandler : IRequestHandler<CreatePermissionTypeCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TipoPermiso> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreatePermissionTypeCommandHandler(IRepositoryAsync<TipoPermiso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreatePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            var newPermission = _mapper.Map<TipoPermiso>(request);

            var data = await _repositoryAsync.AddAsync(newPermission);

            return new Response<int>(data.Id);
        }
    }
}
