using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Todo>()
            .HasOne<User>(u => u.User)
            .WithMany(t => t.Todos)
            .HasForeignKey(t => t.UserId);
    } 

    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
}