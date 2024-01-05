namespace PromAdmin.Core.Componentes.Tests.Dtos;

public class ResultadoMBTIResponse
{
    public string? Resultado { get; set; }
    public string? Definicion { get; set; }
    public string? Descripcion { get; set; }
    public int Extroversion { get; set; }
    public int Introversion { get; set; }
    public int Sensing { get; set; }
    public int Intuition { get; set; }
    public int Thinking { get; set; }
    public int Feeling { get; set; }
    public int Judging { get; set; }
    public int Perceiving { get; set; }
    public IReadOnlyList<string>? Cualidades { get; set; }
    public IReadOnlyCollection<string>? CarrerasRecomendadas { get; set; }
    public IReadOnlyCollection<string>? CarrerasFuturo { get; set; }
    public IReadOnlyCollection<string>? CarrerasEvitar { get; set; }
}