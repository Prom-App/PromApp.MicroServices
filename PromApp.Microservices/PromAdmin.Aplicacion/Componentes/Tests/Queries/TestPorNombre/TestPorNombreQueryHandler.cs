using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Tests.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Tests.Queries.TestPorNombre;

public class TestPorNombreQueryHandler : IRequestHandler<TestPorNombreQuery, TestResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public TestPorNombreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TestResponse> Handle(TestPorNombreQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Test, object>>>
        {
            x => x.Preguntas!,
            x => x.Secciones!
        };

        var test = await _unitOfWork.Repository<Test>().GetEntityAsync(x => x.NombreTest == request.Nombre, includes);

        var testResponse = _mapper.Map<TestResponse>(test);

        foreach (var testPregunta in test.Preguntas!)
        {
            testPregunta.TipoPregunta=
                await _unitOfWork.Repository<TipoPregunta>().GetEntityAsync(x => x.Id == testPregunta.IdSeccion);
            testPregunta.Respuestas =
                (await _unitOfWork.Repository<Respuesta>().GetAsync(x => x.IdPregunta == testPregunta.Id)).ToList();
        }
        return testResponse;
    }
}