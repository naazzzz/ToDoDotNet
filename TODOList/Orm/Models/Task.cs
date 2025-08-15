using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODOList.ORM.Models;

public class Task
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime? DueDate { get; set; }
    
    public DateTime DateCreate { get; set; } = DateTime.UtcNow;
    
    public DateTime? DateUpdate { get; set; }
    
    public DateTime? DateDelete { get; set; }

    public bool IsCompleted { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    
    public User? User { get; set; }
    
    public Task(string title, string description, DateTime? dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
}