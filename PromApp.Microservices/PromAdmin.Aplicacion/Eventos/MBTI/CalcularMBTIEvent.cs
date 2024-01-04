using MediatR;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Eventos.MBTI;

public class CalcularMBTIEvent : IRequest<string>
{
    public string? IdUsuario { get; set; }
    public int IdTestXUsuario { get; set; }
    public IReadOnlyList<RespuestaXTest>? Respuestas { get; set; }
}