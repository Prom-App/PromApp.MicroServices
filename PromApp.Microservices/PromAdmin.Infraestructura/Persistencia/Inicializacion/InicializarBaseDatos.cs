using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PromAdmin.Dominio.Entidades;
using PromAdmin.Infraestructura.Persistencia.Context;

namespace PromAdmin.Infraestructura.Persistencia.Inicializacion;

public class InicializarBaseDatos : IInicializarBaseDatos
{
    private readonly PromDbContext _dbContext;
    private readonly PoblarBaseDatos _dbSeeder;
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public InicializarBaseDatos(PromDbContext dbContext, PoblarBaseDatos dbSeeder,
        UserManager<Usuario> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _dbContext = dbContext;
        _dbSeeder = dbSeeder;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InicializarBaseDatosAsync(CancellationToken cancellationToken)
    {
        if (_dbContext.Database.GetMigrations().Any())
        {
            if ((await _dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
                await _dbContext.Database.MigrateAsync(cancellationToken);
            if (await _dbContext.Database.CanConnectAsync(cancellationToken))
                await _dbSeeder.SeedDatabaseAsync(_userManager, _roleManager, cancellationToken);
        }
    }
}