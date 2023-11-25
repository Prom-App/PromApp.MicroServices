using FluentValidation;
using PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuario;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;

public class ActualizarCiudadCommandValidator : AbstractValidator<ActualizarCiudadCommand>
{
    public ActualizarCiudadCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre es requerido")
            .NotNull().WithMessage("Nombre es requerido")
            .MinimumLength(3).WithMessage("Nombre debe ser mínimo de 3 caracteres");
        RuleFor(x => x.IdDepartamento)
            .GreaterThan(0).WithMessage("Selecciona estado con su respectivo país");
    }
}