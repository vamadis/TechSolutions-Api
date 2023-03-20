using System.Collections.Generic;
using TechSolutions.Domain.Common;

namespace TechSolutions.Domain.Entities
{
    public class TipoPermiso : BaseEntity
    {
        public TipoPermiso()
        {
            Permisos = new HashSet<Permiso>();
        }

        public string Descripcion { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
