using FluentValidation;
using TechSolutions.Application.Dtos.RequestDto;

namespace TechSolutions.Application.Behaviours
{
    public class PermissionValidator : AbstractValidator<PermissionRequestDto>
    {
        public PermissionValidator()
        {
            RuleFor(x => x.NombreEmpleado)
               .NotEmpty().WithMessage("Nombre empleado no puede ser vacio.")
               .MaximumLength(50).WithMessage("Nombre empleado no debe exceder de {MaxLength} caracteres.");

            RuleFor(x => x.ApellidosEmpleado)
               .NotEmpty().WithMessage("Apellidos empleado no puede ser vacio.")
               .MaximumLength(50).WithMessage("Apellidos empleado no debe exceder de {MaxLength} caracteres.");

            RuleFor(x => x.TipoPermiso)
              .NotEmpty().WithMessage("Tipo permiso no puede ser vacio.");

            RuleFor(x => x.FechaPermiso)
                .NotEmpty().WithMessage("Fecha de permiso no puede ser vacia.");

        }
    }
}
