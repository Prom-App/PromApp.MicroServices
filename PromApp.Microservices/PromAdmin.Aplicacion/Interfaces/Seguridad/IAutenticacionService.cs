using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Interfaces.Seguridad;

public interface IAutenticacionService
{
    Task<string> CrearToken(Usuario usuario, IList<string> roles);
    Task<string> ObtenerSesion();
}