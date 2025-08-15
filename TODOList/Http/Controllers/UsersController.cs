using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TODOList.Http.DTO.User;
using TODOList.Services;

namespace TODOList.Http.Controllers;

[ApiController]
[Route("/api/[controller]")]
public sealed class UsersController(IUserService userService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetCollection()
    {
        var users = await userService.GetAll();
        if (users.Count == 0)
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateUserDto userDto)
    {
        var result = await userService.Create(
            userDto.Username,
            userDto.Password,
            userDto.Address);

        return Created("", result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetItem(string id)
    {
        var user = await userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}