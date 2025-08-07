using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Application.DTOs;
using Users.Application.Interfaces;
using Users.Infrastructure.Data;

namespace Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDTO>> GetById([FromRoute] int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPut]
    public async Task<ActionResult<UserResponseDTO>> UpdateUser(UpdateUserDTO dto)
    {
        var user = await _userService.UpdateAsync(dto);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDTO>> CreateUser(CreateUserDTO dto)
    {
        var user = await _userService.CreateAsync(dto);
        return Created("", dto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}
