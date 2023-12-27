using MediatR;
using PromAdmin.Core.Componentes.Tests.Dtos;

namespace PromAdmin.Core.Componentes.Tests.Queries.TestPorNombre;

public class TestPorNombreQuery : IRequest<TestResponse>
{
    public TestPorNombreQuery(string nombre)
    {
        Nombre = string.IsNullOrWhiteSpace(nombre) ? throw new ArgumentNullException(nameof(nombre)) : nombre;
    }

    public string? Nombre { get; set; }
}