using Microsoft.AspNetCore.Mvc;
using TODOList.Services;
using Task = TODOList.ORM.Models.Task;

namespace TODOList.Http.Controllers;

[ApiController]
[Route("/api/[controller]")]
public sealed class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetCollection()
    {
        var tasks = await taskService.GetAll();
        if (tasks.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Task task)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        
        await taskService.Create(task);
        return Ok(task);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetItem(string id)
    {
        var task = await taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        
        return Ok(task);
    }

}