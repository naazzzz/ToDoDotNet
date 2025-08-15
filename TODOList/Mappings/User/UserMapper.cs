using AutoMapper;
using TODOList.Http.DTO.User;

namespace TODOList.Mappings.User;

public sealed class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserDto, ORM.Models.User>();
    }
}