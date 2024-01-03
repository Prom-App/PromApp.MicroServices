using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Tests.Commands.GuardarResultadosTest;

public class GuardarResultadosTestCommandHandler : IRequestHandler<GuardarResultadosTestCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAutenticacionService _authService;
    private readonly UserManager<Usuario> _userManager;

    public GuardarResultadosTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
        IAutenticacionService authService, UserManager<Usuario> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authService = authService;
        _userManager = userManager;
    }

    public async Task<string> Handle(GuardarResultadosTestCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _userManager.FindByEmailAsync(await _authService.ObtenerSesion());

        var test = await _unitOfWork.Repository<Test>().GetEntityAsync(x => x.NombreTest == request.NombreTest);

        var testXUsuario = await _unitOfWork.Repository<TestXUsuario>()
            .GetEntityAsync(x => x.IdUsuario == usuario!.Id && x.IdTest == test.Id && !x.Finalizado);

        if (testXUsuario == null)
        {
            await _unitOfWork.Repository<TestXUsuario>()
                .AddAsync(new TestXUsuario { IdUsuario = usuario!.Id, IdTest = test.Id, Finalizado = request.Finalizado });
            testXUsuario = await _unitOfWork.Repository<TestXUsuario>()
                .GetEntityAsync(x => x.IdUsuario == usuario!.Id && x.IdTest == test.Id && !x.Finalizado);
        }

        var respuestasTest = new List<RespuestaXTest>();
        request.Respuestas!.ForEach(x =>
        {
            respuestasTest.Add(new RespuestaXTest()
            {
                IdTestUsuario = testXUsuario.Id,
                IdPregunta = x.IdPregunta,
                Pregunta = x.Pregunta,
                IdsRespuesta = string.Join(';', x.IdsRespuesta!),
                Respuesta = string.Join(';', x.Respuestas!),
            });
        });

        var respTestExistentes = await
            _unitOfWork.Repository<RespuestaXTest>().GetAsync(x => x.IdTestUsuario == testXUsuario.Id);
        try
        {

            _unitOfWork.Repository<RespuestaXTest>().DeleteRange(respTestExistentes);
            _unitOfWork.Repository<RespuestaXTest>().AddRange(respuestasTest);
            await _unitOfWork.Complete();
            return "la información se guardó correctamente;";
        }
        catch(Exception e)
        {
            throw e;
        }
    }
}