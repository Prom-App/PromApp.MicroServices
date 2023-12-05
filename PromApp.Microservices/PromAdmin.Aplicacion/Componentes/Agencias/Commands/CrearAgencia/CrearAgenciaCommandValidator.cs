using FluentValidation;

namespace PromAdmin.Core.Componentes.Agencias.Commands.CrearAgencia;

public class CrearAgenciaCommandValidator : AbstractValidator<CrearAgenciaCommand>
{
    public CrearAgenciaCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre es requerido")
            .NotNull().WithMessage("Nombre es requerido")
            .MinimumLength(3).WithMessage("Nombre debe ser mínimo de 3 caracteres");
    }
}