using TODOList.Attributes;
using TODOList.ORM.Repositories;
using Task = TODOList.ORM.Models.Task;

namespace TODOList.Services;

public interface ITaskService
{
    public Task<List<Task>> GetAll();

    public Task<Task?> GetById(string id);

    public Task<Task> Create(Task task);
}

[RegisterService]
public sealed class TaskService: ITaskService
{
    private readonly ITaskRepository _taskRepository;
    
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task<List<Task>> GetAll()
    {
        return _taskRepository.GetAllAsync();
    }

    public Task<Task?> GetById(string id)
    {
        return _taskRepository.GetByIdAsync(id);
    }

    public Task<Task> Create(Task task)
    {
        return _taskRepository.CreateAsync(task);
    }
}