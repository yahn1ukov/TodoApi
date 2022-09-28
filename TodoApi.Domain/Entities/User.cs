using TodoApi.Domain.Enums;

namespace TodoApi.Domain.Entities;

public class User 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public UserRole Role { get; set; } = UserRole.USER;
    public ICollection<Todo> Todos { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}