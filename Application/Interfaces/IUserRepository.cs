using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
    public User CreateNewUser(User user);
}