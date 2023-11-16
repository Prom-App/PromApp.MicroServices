using PromApp.Mensajeria.Dominio.Entidades;

namespace PromApp.Mensajeria.Aplicacion.Interfaces;

public interface IEmailService
{
    Task<bool> EnviarCorreo(Mensaje email);
}