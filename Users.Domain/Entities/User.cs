using Users.Domain.Enums;

namespace Users.Domain.Entities;

public class User : BaseEntity
{
    public User(string userName, string email, string passwordHash)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public string UserName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public Roles Role { get; private set; } = Roles.User;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; }

    public void UpdateUser(string userName, string email)
    {
        UserName = userName;
        Email = email;
        UpdatedAt = DateTime.Now;
    }
}
