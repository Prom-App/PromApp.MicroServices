using MediatR;
using Microsoft.Extensions.Options;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Modelos.Options;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Eventos.MBTI;

public class CalcularMBTIEventHandler : IRequestHandler<CalcularMBTIEvent, string>
{
    private readonly List<MBTIQualifyModel> _mbtiQualifyModel;
    private readonly IUnitOfWork _unitOfWork;

    public CalcularMBTIEventHandler(IOptions<List<MBTIQualifyModel>> mbtiQualifyModel, IUnitOfWork unitOfWork)
    {
        _mbtiQualifyModel = mbtiQualifyModel.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CalcularMBTIEvent request, CancellationToken cancellationToken)
    {
        var mbtiResultado = new MBTIResultado
        {
            IdUsuario = request.IdUsuario!,
            IdTestXUsuario = request.IdTestXUsuario
        };

        _mbtiQualifyModel.ForEach(x =>
        {
            var pregunta = request.Respuestas!.FirstOrDefault(y => y.Pregunta!.Contains(x.Pregunta!));
            var flag = pregunta!.Respuesta!.Contains(x.Respuesta!);

            switch (Enum.Parse<DimensionesMBTI>(x.Dimension!))
            {
                case DimensionesMBTI.E_I:
                    mbtiResultado.Extroversion += flag ? 1 : 0;
                    mbtiResultado.Introversion += flag ? 0 : 1;
                    break;
                case DimensionesMBTI.S_N:
                    mbtiResultado.Sensing += flag ? 1 : 0;
                    mbtiResultado.Intuition += flag ? 0 : 1;
                    break;
                case DimensionesMBTI.T_F:
                    mbtiResultado.Thinking += flag ? 1 : 0;
                    mbtiResultado.Feeling += flag ? 0 : 1;
                    break;
                case DimensionesMBTI.J_P:
                    mbtiResultado.Judging += flag ? 1 : 0;
                    mbtiResultado.Perceiving += flag ? 0 : 1;
                    break;
                default:
                    break;
            }

        });

        mbtiResultado.Resultado = (mbtiResultado.Extroversion > mbtiResultado.Introversion ? "E" : "I") +
                                   (mbtiResultado.Sensing > mbtiResultado.Intuition ? "S" : "N") +
                                   (mbtiResultado.Thinking > mbtiResultado.Feeling ? "T" : "F") +
                                   (mbtiResultado.Judging > mbtiResultado.Perceiving ? "J" : "P");

        try
        {
            //await _unitOfWork.Repository<MBTIResultado>().AddAsync(mbtiResultado);
            return $"Se ha calculado correctamente el MBTI con resultado: {mbtiResultado.Resultado}";
        }
        catch (Exception e)
        {
            throw new Exception("Error al guardar el resultado");
        }
        
    }
}