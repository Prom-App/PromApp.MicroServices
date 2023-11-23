using MediatR;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

namespace PromAdmin.Core.Componentes.Usuarios.Queries.UsuarioPorId;

public class UsuarioPorIdQuery : IRequest<AutenticarResponse>
{
    public string? IdUsuario { get; set; }

    public UsuarioPorIdQuery(string idUsuario)
    {
        IdUsuario = idUsuario ?? throw new ArgumentNullException(nameof(idUsuario));
    }
}