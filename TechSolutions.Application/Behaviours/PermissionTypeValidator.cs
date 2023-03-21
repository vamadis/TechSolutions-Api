using FluentValidation;
using TechSolutions.Application.Dtos;
using TechSolutions.Application.Dtos.RequestDto;

namespace TechSolutions.Application.Behaviours
{
    public class PermissionTypeValidator : AbstractValidator<PermissionTypeDto>
    {
        public PermissionTypeValidator()
        {
              RuleFor(x => x.Descripcion)
             .NotEmpty().WithMessage("La descripción no puede ser vacia.")
             .MaximumLength(50).WithMessage("Descripcionno debe exceder de {MaxLength} caracteres.");
        }
    }
}
