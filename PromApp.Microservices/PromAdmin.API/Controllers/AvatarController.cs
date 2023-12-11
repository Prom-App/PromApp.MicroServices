using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromAdmin.Core.Componentes.Avatares.Queries.ListarAvatares;

namespace PromAdmin.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AvatarController : ControllerBase
{
    private readonly IMediator _mediator;

    public AvatarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar", Name = "ListarAvatares")]
    public async Task<IActionResult> ListarAvatares()
    {
        var query = new ListarAvataresQuery();
        return Ok(await _mediator.Send(query));
    }
}