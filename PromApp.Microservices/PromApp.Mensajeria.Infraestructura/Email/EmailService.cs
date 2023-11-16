using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using PromApp.Mensajeria.Aplicacion.Interfaces;
using PromApp.Mensajeria.Dominio.Entidades;

namespace PromApp.Mensajeria.Infraestructura.Email;

public class EmailService:IEmailService
{
    private readonly EmailSettings _mailSettings;
    public EmailService(IOptions<EmailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public async Task<bool> EnviarCorreo(Mensaje emailDestino)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.EmailOrigen);
        email.To.Add(MailboxAddress.Parse(emailDestino.Para));
        email.Subject = emailDestino.Asunto;
        var builder = new BodyBuilder();
        // if (emailDestino.Attachments != null)
        // {
        //     byte[] fileBytes;
        //     foreach (var file in emailDestino.Attachments)
        //     {
        //         if (file.Length > 0)
        //         {
        //             using (var ms = new MemoryStream())
        //             {
        //                 file.CopyTo(ms);
        //                 fileBytes = ms.ToArray();
        //             }
        //             builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //         }
        //     }
        // }
        builder.HtmlBody = emailDestino.Cuerpo;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Servidor, _mailSettings.Puerto, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.EmailOrigen, _mailSettings.Password);
        try
        {
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}