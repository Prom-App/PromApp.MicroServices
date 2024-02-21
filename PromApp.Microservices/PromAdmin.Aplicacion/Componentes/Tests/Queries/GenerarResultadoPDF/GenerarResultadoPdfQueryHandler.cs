using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromAdmin.Core.Interfaces.Negocio;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Dominio.Entidades;
using PromAdmin.Utilidades.Interfaces;
using TipoTest = PromAdmin.Dominio.Entidades.Tests;

namespace PromAdmin.Core.Componentes.Tests.Queries.GenerarResultadoPDF;

public class GenerarResultadoPdfQueryHandler : IRequestHandler<GenerarResultadoPdfQuery, FileContentResult>
{
    private readonly ITestService _testService;
    private readonly UserManager<Usuario> _userManager;
    private readonly IAutenticacionService _authService;
    private readonly IGenerarPdf _generarPdf;

    public GenerarResultadoPdfQueryHandler(ITestService testService, UserManager<Usuario> userManager,
        IAutenticacionService authService, IGenerarPdf generarPdf)
    {
        _testService = testService;
        _userManager = userManager;
        _authService = authService;
        _generarPdf = generarPdf;
    }

    public async Task<FileContentResult> Handle(GenerarResultadoPdfQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _userManager.FindByEmailAsync(await _authService.ObtenerSesion());
        dynamic data;
        switch (Enum.Parse<TipoTest>(request.NombreTest!))
        {
            case TipoTest.Personalidad:
                data = await _testService.ObtenerResultadoMbti(usuario!.Id);
                break;
            default:
                data = default!;
                break;
        }


        byte[] file = await _generarPdf.ConvertirAPdf(request.NombreTest!, JsonConvert.SerializeObject(data));
        return new FileContentResult(file, "application/pdf")
        {
            FileDownloadName =
                $"Personalidad_Resultado_{usuario!.Nombre!.Replace(' ', '_')}_{DateTime.Now.ToString("yyyyMMdd_hh_mm_ss")}"
        };
    }
}