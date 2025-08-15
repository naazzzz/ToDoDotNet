using Microsoft.EntityFrameworkCore;
using TODOList.Attributes;
using TODOList.Configurations;
using TODOList.ORM.Models;

namespace TODOList.ORM.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(string id);
    Task<User> CreateAsync(User entity);
}

[RegisterService]
public sealed class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateAsync(User entity)
    {
        _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}