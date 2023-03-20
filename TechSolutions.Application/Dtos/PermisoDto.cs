using System;

namespace TechSolutions.Application.Dtos
{
    public class PermisoDto
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string PermisoDescripcion { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }

    }
}
