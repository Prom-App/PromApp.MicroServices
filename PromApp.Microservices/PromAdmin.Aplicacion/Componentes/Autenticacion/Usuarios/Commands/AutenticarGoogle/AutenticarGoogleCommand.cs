using MediatR;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.AutenticarGoogle;

public class AutenticarGoogleCommand:IRequest<AutenticarResponse>
{
    public string? Credencial { get; set; }
    public string? TipoAutenticacion { get; set; }
    public string? Token { get; set; }
}