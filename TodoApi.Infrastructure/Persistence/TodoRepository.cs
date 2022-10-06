using Microsoft.EntityFrameworkCore;
using TodoApi.Application.Common.Interfaces.Authentication;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;
using TodoApi.Infrastructure.Data;

namespace TodoApi.Infrastructure.Persistence;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUserAccessor _userAccessor;

    public TodoRepository(ApplicationDbContext context, IUserAccessor userAccessor)
    {
        _context = context;
        _userAccessor = userAccessor;
    }

    public async Task Create(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Todo todo)
    {
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Todo>> GetAll()
    {
        return await _context.Todos.OrderBy(t => t.Text).ToListAsync();
    }

    public async Task<ICollection<Todo>> GetAllByHttpContextId()
    {
        return await _context.Todos.Where(t => t.User.Id == _userAccessor.GetId()).ToListAsync();
    }

    public async Task<Todo?> GetById(Guid todoId)
    {
        return await _context.Todos.FirstOrDefaultAsync(t => t.Id == todoId);
    }

    public async Task Update(Todo todo)
    {
        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
    }
}
