using System.Collections;
using PromAdmin.Core.Interfaces;
using PromAdmin.Infraestructura.Persistencia.Context;

namespace PromAdmin.Infraestructura.Persistencia.Repositorios;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;

    private readonly PromDbContext _context;

    public UnitOfWork(PromDbContext context)
    {
        _context = context;
    }


    public async Task<int> Complete()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error en transacion", e);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        _repositories ??= new Hashtable();

        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type)) return (IBaseRepository<TEntity>)_repositories[type]!;
        var repositoryType = typeof(BaseRepository<>);
        var repositoryInstance =
            Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        _repositories.Add(type, repositoryInstance);

        return (IBaseRepository<TEntity>)_repositories[type]!;
    }
}