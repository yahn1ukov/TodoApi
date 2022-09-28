using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Repositories;

public interface ITodoRepository : IBaseRepository<Todo>
{
    Task<ICollection<Todo>> GetAllByHttpContextId();
}