using MediatR;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.RestablecerContrasena;

public class RestablecerContrasenaCommand: IRequest<string>
{
    public string? ContrasenaAnterior { get; set; }
    public string? ContrasenaNueva { get; set; }
}