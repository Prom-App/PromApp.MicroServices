using FluentValidation;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioAdmin;

public class ActualizarUsuarioAdminCommandValidator : AbstractValidator<ActualizarUsuarioAdminCommand>
{
    public ActualizarUsuarioAdminCommandValidator()
    {
        RuleFor(p => p.Nombre).NotEmpty().WithMessage("Nombre es requerido");
        RuleFor(p => p.Telefono).NotEmpty().WithMessage("Numero de teléfono es requerido");
    }
}