using FluentValidation;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Autenticar;

public class AutenticarUsuarioCommandValidator:AbstractValidator<AutenticarUsuarioCommand>
{
    public AutenticarUsuarioCommandValidator()
    {
        RuleFor(x=>x.Email)
            .NotEmpty().WithMessage("Email es obligatorio")
            .NotNull().WithMessage("Email es obligatorio");
        RuleFor(x => x.Contrasena)
            .NotEmpty().WithMessage("Contraseña es obligatoria")
            .NotNull().WithMessage("Contraseña es obligatoria");
    }
}