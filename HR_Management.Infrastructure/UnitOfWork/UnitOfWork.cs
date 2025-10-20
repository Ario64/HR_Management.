using HR_Management.Application.UintOfWork;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;
using HR_Management.Infrastructure.Repositories;
using System.Collections.Concurrent;

namespace HR_Management.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ConcurrentDictionary<Type, object> _dictionary = new();
    private readonly HRDbContext _context;

    public UnitOfWork(HRDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return (IGenericRepository<T>)_dictionary.GetOrAdd(typeof(T), _ = new GenericRepository<T>(_context));
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
        _context.Dispose();
    }

}
