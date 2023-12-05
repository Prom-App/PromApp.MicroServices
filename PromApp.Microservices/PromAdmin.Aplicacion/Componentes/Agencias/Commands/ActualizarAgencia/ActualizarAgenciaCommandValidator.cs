using FluentValidation;

namespace PromAdmin.Core.Componentes.Agencias.Commands.ActualizarAgencia;

public class ActualizarAgenciaCommandValidator : AbstractValidator<ActualizarAgenciaCommand>
{
    public ActualizarAgenciaCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre es requerido")
            .NotNull().WithMessage("Nombre es requerido")
            .MinimumLength(3).WithMessage("Nombre debe ser mínimo de 3 caracteres");
    }
}