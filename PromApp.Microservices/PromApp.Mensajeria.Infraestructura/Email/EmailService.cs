using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using PromApp.Mensajeria.Aplicacion.Interfaces;
using PromApp.Mensajeria.Dominio.Entidades.Email;

namespace PromApp.Mensajeria.Infraestructura.Email;

public class EmailService:IEmailService
{
    private readonly GmailSettings _gmailSettings;
    public EmailService(IOptions<GmailSettings> gmailSettings)
    {
        _gmailSettings = gmailSettings.Value;
    }
    public async Task<bool> EnviarCorreo(Mensaje emailDestino)
    {
        var mensaje = new MailMessage()
        {
            From = new MailAddress(_gmailSettings.EmailOrigen!),
            Subject = emailDestino.Asunto,
            To = { new MailAddress(emailDestino.Para!) },
            Body = emailDestino.Cuerpo,
            IsBodyHtml = true
        };
        
        var smtp = new SmtpClient(_gmailSettings.Servidor)
        {
            Port = _gmailSettings.Puerto,
            Credentials = new NetworkCredential(_gmailSettings.EmailOrigen,_gmailSettings.Password),
            EnableSsl = true
        };
        try
        {
            await smtp.SendMailAsync(mensaje);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}