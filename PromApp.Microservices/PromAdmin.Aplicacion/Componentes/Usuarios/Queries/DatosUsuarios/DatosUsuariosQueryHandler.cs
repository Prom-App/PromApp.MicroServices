using System.Dynamic;
using System.Linq.Expressions;
using System.Text.Json.Nodes;
using ClosedXML.Excel;
using MediatR;
using Newtonsoft.Json.Linq;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Queries.DatosUsuarios;

public class DatosUsuariosQueryHandler : IRequestHandler<DatosUsuariosQuery, byte[]>
{
    private readonly IUnitOfWork _unitOfWork;

    public DatosUsuariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<byte[]> Handle(DatosUsuariosQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Usuario, object>>>
        {
            x => x.Colegio!,
        };

        var usuarios = await _unitOfWork.Repository<Usuario>()
            .GetAsync(null, x => x.OrderByDescending(y => y.FechaCreacion), includes);


        var preguntas = await _unitOfWork.Repository<Pregunta>().GetAsync(x => x.IdTest == 1);
        var result = new List<JObject>();

        foreach (var user in usuarios)
        {
            var test = await _unitOfWork.Repository<TestXUsuario>()
                .GetAsync(x => x.IdUsuario == user.Id && x.IdTest == 1);

            var resultOnBoarding = test.Count > 0
                ? await _unitOfWork.Repository<RespuestaXTest>()
                    .GetAsync(x => x.IdTestUsuario == test.FirstOrDefault()!.Id)
                : null;
            
            try
            {
                result.Add(new JObject()
                {
                    ["NombreCompleto"] = user.Nombre,
                    ["Email"] = user.Email,
                    ["Telefono"] = user.Telefono,
                    ["Colegio"] = user.Colegio is null ? "" : user.Colegio!.Nombre,
                    ["GradoEscolar"] = user.GradoEscolar,
                    ["FechaCreacion"] = user.FechaCreacion,
                    ["FechaOnboarding"] = resultOnBoarding is null
                        ? ""
                        : resultOnBoarding!.FirstOrDefault()!.FechaCreacion.ToString(),
                    [$"{preguntas[0].Enunciado}"] = resultOnBoarding is null
                        ? ""
                        : resultOnBoarding.FirstOrDefault(x => x.IdPregunta == 1)!.Respuesta,
                    [$"{preguntas[1].Enunciado}"] = resultOnBoarding is null
                        ? ""
                        : resultOnBoarding.FirstOrDefault(x => x.IdPregunta == 2)!.Respuesta,
                    [$"{preguntas[2].Enunciado}"] = resultOnBoarding is null
                        ? ""
                        : resultOnBoarding.FirstOrDefault(x => x.IdPregunta == 3)!.Respuesta,
                    [$"{preguntas[3].Enunciado}"] = resultOnBoarding is null
                        ? ""
                        : resultOnBoarding.FirstOrDefault(x => x.IdPregunta == 4)!.Respuesta,
                    [$"{preguntas[4].Enunciado}"] = resultOnBoarding is null
                        ? ""
                        : resultOnBoarding.FirstOrDefault(x => x.IdPregunta == 5)!.Respuesta
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        return CreateExcelFromJsonObjectList(result);
    }

    private byte[] CreateExcelFromJsonObjectList(List<JObject> jsonObjectList)
    {
        byte[] result;
        using var memoryStream = new MemoryStream();
        using (var workbook = new XLWorkbook())
        {
            // Agregar una hoja al libro
            var worksheet = workbook.Worksheets.Add("Datos");

            // Definir encabezados
            int column = 1;
            foreach (var property in jsonObjectList[0].Properties())
            {
                worksheet.Cell(1, column).Value = property.Name;
                column++;
            }

            // Agregar datos
            int row = 2;
            foreach (var jsonObject in jsonObjectList)
            {
                column = 1;
                foreach (var property in jsonObject.Properties())
                {
                    worksheet.Cell(row, column).Value = property.Value.ToString();
                    column++;
                }

                row++;
            }

            // Guardar el libro en el flujo de memoria
            workbook.SaveAs(memoryStream);
        }

        result = memoryStream.ToArray();

        return result;
    }
}