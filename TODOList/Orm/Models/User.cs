using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TODOList.Configurations.Entity;

namespace TODOList.ORM.Models;

[EntityTypeConfiguration<UserConfiguration, User>]
[Index(nameof(UserName), IsUnique = true)]
public class User: IdentityUser
{
    [Key]
    public override string Id { get; set; }
    
    [JsonIgnore]
    public sealed override string? PasswordHash { get; set; }
    public sealed override string? UserName { get; set; }
    
    public DateTime DateCreate { get; set; } = DateTime.UtcNow;
    
    public DateTime? DateUpdate { get; set; } = DateTime.UtcNow;
    
    public DateTime? DateDelete { get; set; }

    public Address? Address { get; set; }
    
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
    
    public User(Address? address = null)
    {
        Address = address;

    }
    public User(string username, Address? address = null): base(username)
    {
        Address = address;
    }
}