using HR_Management.Application.UintOfWork;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;
using HR_Management.Infrastructure.Repositories;
using System.Collections.Concurrent;

namespace HR_Management.Infrastructure.UnitOfWork;

public class UnitOfWork(HRDbContext context) : IUnitOfWork, IDisposable
{
    private readonly ConcurrentDictionary<Type, object> _dictionary = new();

    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return (IGenericRepository<T>)_dictionary.GetOrAdd(typeof(T), _ = new GenericRepository<T>(context));
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
        => context.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
        context.Dispose();
    }

}
