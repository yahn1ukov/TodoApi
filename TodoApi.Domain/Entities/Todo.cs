namespace TodoApi.Domain.Entities;

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Text { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public User User { get; set; }
    public bool IsEdited { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}