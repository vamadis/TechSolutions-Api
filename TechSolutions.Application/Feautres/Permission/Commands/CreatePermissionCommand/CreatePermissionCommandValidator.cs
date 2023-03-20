﻿using FluentValidation;

namespace TechSolutions.Application.Feautres.Permission.Commands.CreatePermissionCommand
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
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
