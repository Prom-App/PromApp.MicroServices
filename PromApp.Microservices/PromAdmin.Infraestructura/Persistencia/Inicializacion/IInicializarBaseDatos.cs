namespace PromAdmin.Infraestructura.Persistencia.Inicializacion;

public interface IInicializarBaseDatos
{
    Task InicializarBaseDatosAsync(CancellationToken cancellationToken);
}