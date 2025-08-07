using Users.Application.DTOs;
using Users.Application.Mappings;
using Users.Application.Interfaces;
using Users.Domain.Interfaces;

namespace Users.Application.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponseDTO> CreateAsync(CreateUserDTO createUserdto)
    {
        if(createUserdto == null) throw new ArgumentNullException(nameof(createUserdto));

        string passwordHash = string.Empty;

        var user = createUserdto.ToEntity(passwordHash);

        await _userRepository.CreateAsync(user);
        return user.ToUserResponseDTO();
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        if (users == null) throw new ArgumentNullException(nameof(users));
        return users.Select(u => u.ToUserResponseDTO());
    }

    public async Task<UserResponseDTO> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new ArgumentNullException(nameof(user));
        return user.ToUserResponseDTO();
    }

    public async Task<UserResponseDTO> UpdateAsync(UpdateUserDTO updateUserdto)
    {
        if (updateUserdto == null) throw new ArgumentNullException(nameof(updateUserdto));
        if (updateUserdto.Id <= 0) throw new ArgumentException("Id inválido.");

        var userEntity = await _userRepository.GetByIdAsync(updateUserdto.Id);
        userEntity.ApplyUpdate(updateUserdto);

        var updatedUser = await _userRepository.UpdateAsync(userEntity);

        return updatedUser.ToUserResponseDTO();
    }
}
