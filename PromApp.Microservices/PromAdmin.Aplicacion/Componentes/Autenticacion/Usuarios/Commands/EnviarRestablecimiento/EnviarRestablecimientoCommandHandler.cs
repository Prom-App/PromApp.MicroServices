using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Exceptions;
using PromAdmin.Dominio.Entidades;
using PromApp.Mensajeria.Aplicacion.Interfaces;
using PromApp.Mensajeria.Dominio.Entidades.Email;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.EnviarRestablecimiento;

public class EnviarRestablecimientoCommandHandler : IRequestHandler<EnviarRestablecimientoCommand, string>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IEmailService _emailService;

    public EnviarRestablecimientoCommandHandler(UserManager<Usuario> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
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
        var emailMessage = new Mensaje()
        {
            Para = request.Email,
            Cuerpo = "Para restablecer su contraseña, por favor de clic aquí: ",
            Asunto = "Cambiar clave"
        };
        
        var result = await _emailService.EnviarCorreo(emailMessage);
        
        if (!result) throw new Exception("Email could not be sent");

        return $"Se ha enviado un link a tu correo electrónico: {request.Email}";; //$"Email has been sent to {request.Email}";
    }
}