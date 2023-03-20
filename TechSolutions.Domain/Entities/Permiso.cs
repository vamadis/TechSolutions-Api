using System;
using TechSolutions.Domain.Common;

namespace TechSolutions.Domain.Entities
{
    public class Permiso : BaseEntity
    {
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }

        public virtual TipoPermiso TipoPermisoNavigation { get; set; }
    }
}
