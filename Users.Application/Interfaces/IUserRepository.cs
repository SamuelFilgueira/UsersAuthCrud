using Users.Application.DTOs;

namespace Users.Application.Interfaces;

public interface IUserRepository
{
    Task<UserResponseDTO> GetAllUsersAsync();
    Task<UserResponseDTO> GetUserByIdAsync(int id);
    Task<UserResponseDTO> CreateUserAsync(CreateUserDTO userDTO);
    Task<UserResponseDTO> UpdateUserAsync(UpdateUserDTO userDTO);
    Task<UserResponseDTO> DeleteUserAsync(int id);

}
