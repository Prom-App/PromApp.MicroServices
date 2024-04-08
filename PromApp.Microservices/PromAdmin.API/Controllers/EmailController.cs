using Microsoft.AspNetCore.Mvc;
using PromApp.Mensajeria.Aplicacion.Interfaces;
using PromApp.Mensajeria.Dominio.Entidades.Email;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmailController:ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost(Name = "EnviarCorreo")]
    public async Task<IActionResult> EnviarCorreo(Mensaje mensaje)
    {
        return Ok(await _emailService.EnviarCorreo(mensaje));
    }
}