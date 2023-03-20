using FluentValidation;

namespace TechSolutions.Application.Feautres.PermissionType.Commands.UpdatePermissionTypeCommand
{
    public class UpdatePermissionTypeCommandValidator : AbstractValidator<UpdatePermissionTypeCommand>
    {
        public UpdatePermissionTypeCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(x => x.Descripcion)
              .NotEmpty().WithMessage("La descripción no puede ser vacia.")
              .MaximumLength(50).WithMessage("Descripcionno debe exceder de {MaxLength} caracteres.");
        }
    }
}
