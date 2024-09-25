using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoBackend.Domain.Entities.Common;
using TodoBackend.Domain.Repositories;

namespace TodoBackend.Persistence.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(ApplicationDbContext context) // sonradan protected'a çevirilebilir
    {
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var queryableEntity = DbSet.AsQueryable(); // This is a queryable object.  

        return await queryableEntity.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        var queryableEntity = DbSet.AsQueryable();
        if (filter != null)
        {
            queryableEntity =
                queryableEntity.Where(filter); // Where function is used to filter the data like a SQL query
        }

        return await queryableEntity.SingleOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        if (filter != null)
        {
            return
                await DbSet.AsNoTracking().Where(filter)
                    .ToListAsync(); //asnotracking is used to not track the changes in the entity. otherwise it will be tracked. Tracked means that the entity is being watched by the context. And by default, the entity is tracked.
        }

        return await DbSet.AsNoTracking().ToListAsync();
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        if (filter != null)
        {
            return await DbSet.AsNoTracking().CountAsync(filter); //No need where, count has a filter in itself
        }

        return await DbSet.AsNoTracking().CountAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
    
    public void DeleteRange(IEnumerable<TEntity> entity)
    {
        _context.Set<TEntity>().RemoveRange(entity);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}