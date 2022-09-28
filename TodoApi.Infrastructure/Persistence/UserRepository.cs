using TodoApi.Domain.Repositories;
using TodoApi.Domain.Entities;
using TodoApi.Infrastructure.Data;
using TodoApi.Application.Common.Interfaces.Authentication;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUserAccessor _userAccessor;

    public UserRepository(ApplicationDbContext context, IUserAccessor userAccessor)
    {
        _context = context;
        _userAccessor = userAccessor;
    }

    public async Task Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByHttpContextId()
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == _userAccessor.GetId());
    }

    public async Task<User?> GetById(Guid userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}