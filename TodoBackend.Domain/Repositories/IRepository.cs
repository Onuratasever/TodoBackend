using System.Linq.Expressions;
using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<List<TEntity>> GetAllAsync();
    
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entity);
    Task<int> SaveChangesAsync();

}