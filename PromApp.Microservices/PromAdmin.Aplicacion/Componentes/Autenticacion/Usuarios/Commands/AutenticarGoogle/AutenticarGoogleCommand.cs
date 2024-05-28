using MediatR;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;
using PromAdmin.Core.Modelos;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.AutenticarGoogle;

public class AutenticarGoogleCommand:IRequest<BaseApiResponse<AutenticarResponse>>
{
    public string? Credencial { get; set; }
    public string? TipoAutenticacion { get; set; }
    public string? Token { get; set; }
}