using PromAdmin.Core.Componentes.Tests.Dtos;

namespace PromAdmin.Core.Interfaces.Negocio;

public interface ITestService
{
    Task<ResultadoMBTIResponse> ObtenerResultadoMbti(string idUsuario);
}