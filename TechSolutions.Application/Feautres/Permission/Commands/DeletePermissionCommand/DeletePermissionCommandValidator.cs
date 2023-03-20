using FluentValidation;

namespace TechSolutions.Application.Feautres.Permission.Commands.DeletePermissionCommand
{
    public class DeletePermissionCommandValidator: AbstractValidator<DeletePermissionCommand>
    {
        public DeletePermissionCommandValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}
