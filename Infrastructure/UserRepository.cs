using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;
    
    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public User GetUserByEmail(string email)
    {
        return _context.UserTable.FirstOrDefault(u => u.Email == email) ?? throw new KeyNotFoundException("There was no user with email "+email);
    }

    public User CreateNewUser(User user)
    {
        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }
    
}