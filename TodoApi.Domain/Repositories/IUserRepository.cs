using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User> 
{
    Task<User?> GetByHttpContextId();
    Task<User?> GetByUsername(string username);
}