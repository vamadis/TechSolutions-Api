using System;

namespace TechSolutions.Application.Dtos.RequestDto
{
    public class PermissionRequestDto
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}
