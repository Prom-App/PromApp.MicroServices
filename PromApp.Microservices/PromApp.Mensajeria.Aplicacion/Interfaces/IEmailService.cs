using PromApp.Mensajeria.Dominio.Entidades;
using PromApp.Mensajeria.Dominio.Entidades.Email;

namespace PromApp.Mensajeria.Aplicacion.Interfaces;

public interface IEmailService
{
    Task<bool> EnviarCorreo(Mensaje email);
}