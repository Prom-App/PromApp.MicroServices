using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PromAdmin.Core.Componentes.Tests.Queries.GenerarResultadoPDF;

public class GenerarResultadoPdfQuery: IRequest<FileContentResult>
{
    public string? NombreTest { get; set; }
}