using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Componentes.Tests.Dtos;
using PromAdmin.Core.Eventos.MBTI;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Tests.Queries.ObtenerResultadoMBTI;

public class
    ObtenerResultadoMBTIQueryHandler : IRequestHandler<ObtenerResultadoMBTIQuery, IReadOnlyList<ResultadoMBTIResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAutenticacionService _authService;
    private readonly UserManager<Usuario> _userManager;
    private readonly IMediator _mediator;

    public ObtenerResultadoMBTIQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAutenticacionService authService,
        UserManager<Usuario> userManager, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authService = authService;
        _userManager = userManager;
        _mediator = mediator;
    }

    public async Task<IReadOnlyList<ResultadoMBTIResponse>> Handle(ObtenerResultadoMBTIQuery request,
        CancellationToken cancellationToken)
    {
        var usuario = await _userManager.FindByEmailAsync(await _authService.ObtenerSesion());

        var test = await _unitOfWork.Repository<Test>().GetEntityAsync(x => x.NombreTest == "Personalidad");

        var testXUsuario = await _unitOfWork.Repository<TestXUsuario>()
            .GetAsync(x => x.IdUsuario == usuario!.Id && x.IdTest == test.Id && x.Finalizado);

        var resultadosMBTI = await _unitOfWork.Repository<MBTIResultado>()
            .GetAsync(x => x.IdUsuario == usuario!.Id && testXUsuario.Select(y => y.Id).Contains(x.IdTestXUsuario));

        foreach (var resultado in testXUsuario.Where(x => !resultadosMBTI.Select(y => y.IdTestXUsuario).Contains(x.Id)))
        {
            await _mediator.Send(new CalcularMBTIEvent()
            {
                IdUsuario = usuario!.Id,
                IdTestXUsuario = resultado.Id,
                Respuestas = await _unitOfWork.Repository<RespuestaXTest>()
                    .GetAsync(x => x.IdTestUsuario == resultado.Id)
            }, cancellationToken);
        }

        resultadosMBTI = await _unitOfWork.Repository<MBTIResultado>()
            .GetAsync(x => x.IdUsuario == usuario!.Id && testXUsuario.Select(y => y.Id).Contains(x.IdTestXUsuario));

        var includes = new List<Expression<Func<Personalidad, object>>>
        {
            // x => x.CualidadesXPersonalidad!,
            // x => x.CarrerasRecomendadas!,
            // x => x.CarrerasFuturo!,
            // x => x.CarrerasEvitar!,
        };

        var results = _mapper.Map<IReadOnlyList<ResultadoMBTIResponse>>(resultadosMBTI);
        
        foreach (var resultado in results)
        {
            var personalidad = await _unitOfWork.Repository<Personalidad>()
                .GetEntityAsync(x => x.Codigo == resultado.Resultado, includes);

            resultado.Definicion = personalidad.Definicion;
            resultado.Descripcion = personalidad.Descripcion;
            resultado.CarrerasRecomendadas = personalidad.Recomendadas!.Split(',');
            resultado.CarrerasFuturo = personalidad.Futuro!.Split(',');
            resultado.CarrerasEvitar = personalidad.Evitar!.Split(',');
                
            // resultado.CarrerasRecomendadas = (await _unitOfWork.Repository<Carrera>()
            //         .GetAsync(x => personalidad.CarrerasRecomendadas!.Select(c => c.IdCarrera).Contains(x.Id)))
            //     .Select(y => y.Nombre).ToList()!;
            // resultado.CarrerasFuturo = (await _unitOfWork.Repository<Carrera>()
            //         .GetAsync(x => personalidad.CarrerasFuturo!.Select(c => c.IdCarrera).Contains(x.Id)))
            //     .Select(y => y.Nombre).ToList()!;
            // resultado.CarrerasEvitar = (await _unitOfWork.Repository<Carrera>()
            //         .GetAsync(x => personalidad.CarrerasEvitar!.Select(c => c.IdCarrera).Contains(x.Id)))
            //     .Select(y => y.Nombre).ToList()!;
            // resultado.Cualidades = (await _unitOfWork.Repository<Cualidad>()
            //         .GetAsync(x => personalidad.CualidadesXPersonalidad!.Select(c => c.IdCualidad).Contains(x.Id)))
            //     .Select(y => y.Caracteristica).ToList()!;
        }

        return results;
    }
}