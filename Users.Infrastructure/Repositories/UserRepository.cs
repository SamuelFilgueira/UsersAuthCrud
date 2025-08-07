using Microsoft.EntityFrameworkCore;
using Users.Application.DTOs;
using Users.Domain.Entities;
using Users.Domain.Interfaces;
using Users.Infrastructure.Data;

namespace Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        if(user == null) throw new ArgumentNullException(nameof(user));
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null) throw new InvalidOperationException($"Usuário com ID {id} não encontrado.");
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
        
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) throw new InvalidOperationException($"Usuário com ID {id} não encontrado.");
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var updatedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        if(updatedUser == null ) throw new ArgumentNullException(nameof(user));

        updatedUser.UpdateUser(user.UserName, user.Email);

        await _dbContext.SaveChangesAsync();

        return updatedUser;

    }
}
