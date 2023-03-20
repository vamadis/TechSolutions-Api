using Ardalis.Specification;
using System;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Application.Specifications
{
    public class PagedPermissionsSpecification : Specification<Permiso>
    {
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public PagedPermissionsSpecification(int pageSize,int pageNumber, string nombreEmpleado, string apellidosEmpleado)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(nombreEmpleado))
                Query.Search(x => x.NombreEmpleado, $"%{nombreEmpleado}%");

            if (!string.IsNullOrEmpty(apellidosEmpleado))
                Query.Search(x => x.ApellidosEmpleado, $"%{apellidosEmpleado}%");
        }
    }
}
