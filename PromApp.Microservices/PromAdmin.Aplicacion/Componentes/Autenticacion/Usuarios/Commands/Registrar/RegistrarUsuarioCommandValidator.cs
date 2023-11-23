using FluentValidation;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Registrar;

public class RegistrarUsuarioCommandValidator : AbstractValidator<RegistrarUsuarioCommand>
{
    public RegistrarUsuarioCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email es obligatorio")
            .NotNull().WithMessage("Email es obligatorio");
        RuleFor(x => x.Contrasena)
            .NotEmpty().WithMessage("Contraseña es obligatoria")
            .NotNull().WithMessage("Contraseña es obligatoria");
        RuleFor(x => x.ConfirmaContrasena)
            .NotEmpty().WithMessage("Contraseña es obligatoria")
            .NotNull().WithMessage("Contraseña es obligatoria");
    }
}