using Microsoft.AspNetCore.Identity;
using TODOList.Attributes;
using TODOList.ORM.Models;
using TODOList.ORM.Repositories;

namespace TODOList.Services;

public interface IUserService
{
    Task<List<User>> GetAll();

    Task<User?> GetById(string id);

    Task<User> Create(string username, string password, Address? address = null);
}

[RegisterService]
public sealed class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<object> _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher<object> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    public Task<List<User>> GetAll()
    {
        return _userRepository.GetAllAsync();
    }

    public Task<User?> GetById(string id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public Task<User> Create(string username, string password, Address? address = null)
    {
        return _userRepository.CreateAsync(
            new User(username, address)
            {
                PasswordHash = _passwordHasher.HashPassword(null, password),
            });
    }
}