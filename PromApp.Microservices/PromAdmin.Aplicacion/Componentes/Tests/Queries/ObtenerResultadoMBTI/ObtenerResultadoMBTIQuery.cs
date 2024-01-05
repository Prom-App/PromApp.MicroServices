using MediatR;
using PromAdmin.Core.Componentes.Tests.Dtos;

namespace PromAdmin.Core.Componentes.Tests.Queries.ObtenerResultadoMBTI;

public class ObtenerResultadoMBTIQuery : IRequest<IReadOnlyList<ResultadoMBTIResponse>>
{
}