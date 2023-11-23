using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PromAdmin.Core.Componentes.Roles.Queries.ListarRoles;

public class ListarRolesQueryHandler : IRequestHandler<ListarRolesQuery, List<string>>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public ListarRolesQueryHandler(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<string>> Handle(ListarRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);

        return roles.OrderBy(x => x.Name).Select(x => x.Name)!.ToList<string>();
    }
}