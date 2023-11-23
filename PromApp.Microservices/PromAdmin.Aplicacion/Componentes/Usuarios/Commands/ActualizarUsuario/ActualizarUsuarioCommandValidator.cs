using FluentValidation;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuario;

public class ActualizarUsuarioCommandValidator : AbstractValidator<ActualizarUsuarioCommand>
{
    public ActualizarUsuarioCommandValidator()
    {
        RuleFor(p => p.Nombre).NotEmpty().WithMessage("Nombre es requerido");
        RuleFor(p => p.Telefono).NotEmpty().WithMessage("Numero de teléfono es requerido");
        RuleFor(p => p.Direccion).NotEmpty().WithMessage("Dirección es requerida");
        RuleFor(p => p.IdCiudad).LessThan(1).WithMessage("Ciudad es requerida");
        RuleFor(p => p.IdColegio).LessThan(1).WithMessage("Colegio es requerido");
        RuleFor(p => p.IdGenero).LessThan(1).WithMessage("Genero es requerido");
    }
}