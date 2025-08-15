using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODOList.ORM.Models;

namespace TODOList.Configurations.Entity;

public sealed class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        var addressConverter = new ValueConverter<Address?, string>(
            v => v != null ? JsonSerializer.Serialize(v, new JsonSerializerOptions()) : null,
            v => v == null ? null : JsonSerializer.Deserialize<Address>(v, new JsonSerializerOptions()));
        
        modelBuilder
            .Property(u => u.Address)
            .HasConversion(addressConverter)
            .HasColumnName("Address");
    }
}