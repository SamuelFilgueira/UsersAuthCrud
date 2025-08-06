using Users.Application.DTOs;

namespace Users.Application.Interfaces;

public interface IUserService
{
    Task<UserResponseDTO> GetByIdAsync(int id);
    Task<IEnumerable<UserResponseDTO>> GetAllAsync();
    Task<UserResponseDTO> CreateAsync(CreateUserDTO createUserdto);
    Task<UserResponseDTO> UpdateAsync(UpdateUserDTO updateUserdto);
    Task DeleteAsync(int id);
}
