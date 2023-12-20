using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Core.Modelos.Token;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Infraestructura.Servicios.Seguridad;

public class AutenticacionService : IAutenticacionService
{
    private readonly IHttpContextAccessor _httpContextAccesor;
    private readonly JwtSettings _jwtSettings;

    public AutenticacionService(IHttpContextAccessor httpContextAccesor, IOptions<JwtSettings> jwtSettings)
    {
        _httpContextAccesor = httpContextAccesor;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<string> ObtenerSesion()
    {
        return await Task.FromResult(
            _httpContextAccesor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!
                .Value);
    }

    public Task<string> CrearToken(Usuario usuario, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.NameId, usuario.Email!),
            new("userId", usuario.Id),
            new("name", usuario.Nombre! ?? string.Empty),
            new("email", usuario.Email!),
            new("avatar", usuario.Avatar != null ? usuario.Avatar!.Url! : string.Empty),
            new("username", usuario.UserName!),
        };
        claims.AddRange(roles!.Select(rol => new Claim(ClaimTypes.Role, rol)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secreto!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Expiracion),
            SigningCredentials = credentials,
            Audience = _jwtSettings.Audiencia,
            Issuer = _jwtSettings.Emisor,
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}