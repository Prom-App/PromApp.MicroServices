using FluentValidation;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;

public class CrearCiudadCommandValidator : AbstractValidator<CrearCiudadCommand>
{
    public CrearCiudadCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre es requerido")
            .NotNull().WithMessage("Nombre es requerido")
            .MinimumLength(3).WithMessage("Nombre debe ser mínimo de 3 caracteres");
        RuleFor(x => x.IdDepartamento)
            .GreaterThan(0).WithMessage("Selecciona estado con su respectivo país");
    }
}