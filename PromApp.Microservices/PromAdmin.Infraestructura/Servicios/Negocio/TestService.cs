using System.Linq.Expressions;
using AutoMapper;
using PromAdmin.Core.Componentes.Tests.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Negocio;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Infraestructura.Servicios.Negocio;

public class TestService : ITestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultadoMBTIResponse> ObtenerResultadoMbti(string idUsuario)
    {
        var resultadoMbti = await _unitOfWork.Repository<MBTIResultado>()
            .GetAsync(x => x.IdUsuario == idUsuario);

        var includes = new List<Expression<Func<Personalidad, object>>>
        {
            x => x.CualidadesXPersonalidad!,
            x => x.CarrerasRecomendadas!,
            x => x.CarrerasFuturo!,
            x => x.CarrerasEvitar!,
        };

        var result = _mapper.Map<ResultadoMBTIResponse>(resultadoMbti.MaxBy(x => x.FechaCreacion));

        var personalidad = await _unitOfWork.Repository<Personalidad>()
            .GetEntityAsync(x => x.Codigo == result.Resultado, includes);

        result.Definicion = personalidad.Definicion;
        result.Descripcion = personalidad.Descripcion;
        result.CarrerasRecomendadas = (await _unitOfWork.Repository<Carrera>()
                .GetAsync(x => personalidad.CarrerasRecomendadas!.Select(c => c.IdCarrera).Contains(x.Id)))
            .Select(y => y.Nombre).ToList()!;
        result.CarrerasFuturo = (await _unitOfWork.Repository<Carrera>()
                .GetAsync(x => personalidad.CarrerasFuturo!.Select(c => c.IdCarrera).Contains(x.Id)))
            .Select(y => y.Nombre).ToList()!;
        result.CarrerasEvitar = (await _unitOfWork.Repository<Carrera>()
                .GetAsync(x => personalidad.CarrerasEvitar!.Select(c => c.IdCarrera).Contains(x.Id)))
            .Select(y => y.Nombre).ToList()!;
        result.Cualidades = (await _unitOfWork.Repository<Cualidad>()
                .GetAsync(x => personalidad.CualidadesXPersonalidad!.Select(c => c.IdCualidad).Contains(x.Id)))
            .Select(y => y.Caracteristica).ToList()!;
        
        return result;
    }
}