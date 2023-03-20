using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechSolutions.Application.Interfaces;
using TechSolutions.Application.Wrappers;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Feautres.Permission.Commands.UpdatePermissionCommand
{
    public class UpdatePermissionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }

    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Permiso> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdatePermissionCommandHandler(IRepositoryAsync<Permiso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _repositoryAsync.GetByIdAsync(request.Id);

            if (permission == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                permission.NombreEmpleado = request.NombreEmpleado;
                permission.ApellidosEmpleado = request.ApellidosEmpleado;
                permission.TipoPermiso = request.TipoPermiso;
                permission.FechaPermiso = request.FechaPermiso;

                await _repositoryAsync.UpdateAsync(permission);

                return new Response<int>(permission.Id);
            }
        }
    }
}
