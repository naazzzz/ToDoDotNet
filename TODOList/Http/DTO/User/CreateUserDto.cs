using TODOList.ORM.Models;

namespace TODOList.Http.DTO.User;

public sealed class CreateUserDto(string username, string password, Address? address)
{
    public string Username { get; set; } = username;

    public string Password { get; set; } = password;

    public Address? Address { get; set; } = address;
}