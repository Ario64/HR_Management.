using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Condtructor

    private readonly HRDbContext _context;

    public GenericRepository(HRDbContext context)
    {
        _context = context;
    }

    #endregion

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.Set<T>().ToListAsync(cancellationToken);
        return entities;
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
        return entity;
    }

    public async Task<bool> IsExist(object id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>().FindAsync(new[] { id }, cancellationToken);
        return entity != null;
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
