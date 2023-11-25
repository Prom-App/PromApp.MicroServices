using MediatR;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Specifications.Usuarios;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Queries.PaginacionUsuarios;

public class PaginacionUsuariosQueryHandler : IRequestHandler<PaginacionUsuariosQuery, PaginacionDto<Usuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PaginacionUsuariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginacionDto<Usuario>> Handle(PaginacionUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        var userSpecParams = new UserSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };

        var userSpec = new UserSpecification(userSpecParams);
        var users = await _unitOfWork.Repository<Usuario>().GetAllWithSpec(userSpec);

        var specCount = new UserForCountingSpecification(userSpecParams);
        var totalUsers = await _unitOfWork.Repository<Usuario>().CountAsync(specCount);

        var rounded = Math.Ceiling(Convert.ToDecimal(totalUsers) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);

        var pagination = new PaginacionDto<Usuario>
        {
            Count = totalUsers,
            Data = users,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = users.Count
        };

        return pagination;
    }
}