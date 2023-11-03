namespace PromAdmin.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}