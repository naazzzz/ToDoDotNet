using Microsoft.EntityFrameworkCore;
using TODOList.Attributes;
using TODOList.Configurations;
using Task = TODOList.ORM.Models.Task;

namespace TODOList.ORM.Repositories;

public interface ITaskRepository
{
    Task<List<Task>> GetAllAsync();
    Task<Task?> GetByIdAsync(string id);
    Task<Task> CreateAsync(Task entity);
}

[RegisterService]
public sealed class TaskRepository : ITaskRepository
{
    private readonly ApplicationContext _context;

    public TaskRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Task>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task?> GetByIdAsync(string id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Task> CreateAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }
}