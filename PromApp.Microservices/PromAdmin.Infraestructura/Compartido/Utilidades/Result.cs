namespace PromAdmin.Infraestructura.Compartido.Utilidades;

public class Result
{
    public bool Fallo => !Exitoso;
    public string? Mensaje { get; set; }
    private bool Exitoso { get; init; }

    private static Result Fail() => new()
    {
        Exitoso = false
    };

    private static Result Fail(string mensaje) => new()
    {
        Exitoso = false,
        Mensaje = mensaje
    };

    public static Task<Result> FailAsync() => Task.FromResult(Fail());
    public static Task<Result> FailAsync(string mensaje) => Task.FromResult(Fail(mensaje));

    private static Result Success() => new()
    {
        Exitoso = true
    };

    private static Result Success(string mensaje) => new()
    {
        Exitoso = true,
        Mensaje = mensaje
    };

    public static Task<Result> SuccessAsync() => Task.FromResult(Success());
    public static Task<Result> SuccessAsync(string mensaje) => Task.FromResult(Success(mensaje));
}