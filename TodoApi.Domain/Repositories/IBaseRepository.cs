namespace TodoApi.Domain.Repositories;

public interface IBaseRepository<T>
{
    Task Create(T entity);
    Task<T?> GetById(Guid id);
    Task<ICollection<T>> GetAll();
    Task Update(T entity);
    Task Delete(T entity);
}