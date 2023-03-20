using FluentValidation;

namespace TechSolutions.Application.Feautres.PermissionType.Commands.CreatePermissionTypeCommand
{
    public class CreatePermissionTypeCommandValidator : AbstractValidator<CreatePermissionTypeCommand>
    {
        public CreatePermissionTypeCommandValidator()
        {
            RuleFor(x => x.Descripcion)
              .NotEmpty().WithMessage("La descripción no puede ser vacia.")
              .MaximumLength(50).WithMessage("Descripcionno debe exceder de {MaxLength} caracteres.");
        }
    }
}
