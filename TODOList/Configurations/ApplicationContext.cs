using Microsoft.EntityFrameworkCore;
using TODOList.ORM.Models;
using Task = TODOList.ORM.Models.Task;

namespace TODOList.Configurations;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    
    public DbSet<User> Users { get; set; }

    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}