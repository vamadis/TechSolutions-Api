using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;
using AutoMapper;

namespace TechSolutions.Application.Feautres.Permission.Commands.CreatePermissionCommand
{
    public class CreatePermissionCommand : IRequest<Response<int>>
    {
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }

    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Permiso> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreatePermissionCommandHandler(IRepositoryAsync<Permiso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var newPermission = _mapper.Map<Permiso>(request);
            
            var data = await _repositoryAsync.AddAsync(newPermission);
        
            return new Response<int>(data.Id);
        }
    }
}
