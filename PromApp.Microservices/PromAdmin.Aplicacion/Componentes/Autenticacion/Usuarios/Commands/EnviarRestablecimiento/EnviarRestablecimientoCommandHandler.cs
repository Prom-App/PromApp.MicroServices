using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Exceptions;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.EnviarRestablecimiento;

public class EnviarRestablecimientoCommandHandler : IRequestHandler<EnviarRestablecimientoCommand, string>
{
    private readonly UserManager<Usuario> _userManager;

    public EnviarRestablecimientoCommandHandler(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(EnviarRestablecimientoCommand request, CancellationToken cancellationToken)
    {
        var usuarioExistente = await _userManager.FindByEmailAsync(request.Email!);
        if (usuarioExistente is null)
        {
            throw new NotFoundException(nameof(Usuario), request.Email!);
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(usuarioExistente);
        var tokenBytes = Encoding.UTF8.GetBytes(token);
        token = Convert.ToBase64String(tokenBytes);

        // todo: Integración Correo electrónico
        // var emailMessage = new EmailMessage()
        // {
        //     To = request.Email,
        //     Body = "Para restablecer su contraseña, por favor de clic aquí: ",
        //     Subject = "Cambiar clave"
        // };

        // var result = await _emailService.SendEmail(emailMessage, token);

        // if (!result) throw new Exception("Email could not be sent");

        return token; //$"Email has been sent to {request.Email}";
    }
}