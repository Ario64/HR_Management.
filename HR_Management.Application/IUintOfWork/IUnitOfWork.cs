using HR_Management.Domain.Repositories;

namespace HR_Management.Application.UintOfWork;

public interface IUnitOfWork
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void SaveChanges();
}
