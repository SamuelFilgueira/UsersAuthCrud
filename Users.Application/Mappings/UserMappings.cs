using System.Runtime.CompilerServices;
using Users.Application.DTOs;
using Users.Domain.Entities;

namespace Users.Application.Mappings;

public static class UserMappings
{
    public static UserResponseDTO ToUserResponseDTO(this User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        };
    }

    public static User ToEntity(this CreateUserDTO dto, string passwordHash)
    {
        return new User(dto.UserName, dto.Email, passwordHash);
    }

    public static UpdateUserDTO ToUpdateUserDTO(this User user)
    {
        return new UpdateUserDTO
        {
            UserName = user.UserName,
            Email = user.Email,
        };
    }


    public static void ApplyUpdate(this User user, UpdateUserDTO dto)
    {
        user.UpdateUser(dto.UserName, dto.Email);
    }
}
