using MediatR;
using PromAdmin.Core.Componentes.Tests.Dtos;

namespace PromAdmin.Core.Componentes.Tests.Commands.GuardarResultadosTest;

public class GuardarResultadosTestCommand:IRequest<string>
{
    public string? NombreTest { get; set; }
    public bool Finalizado { get; set; }
    public List<RespuestasRequest>? Respuestas { get; set; }
}