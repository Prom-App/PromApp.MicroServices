namespace PromAdmin.Core.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string nombre, object valor) : base($"Entidad \"{nombre}\" ({valor}) no encontrada")
    {
    }
}