namespace HR_Management.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}