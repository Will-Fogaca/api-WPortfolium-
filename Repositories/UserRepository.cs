using WillPortfolio_Api.Data;
using WillPortfolio_Api.Domain.Entities;
using WillPortfolio_Api.Repositories.Interfaces;

namespace WillPortfolio_Api.Repositories;

public class UserRepository :  IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public UserEntity? GetUserById(Guid id)
    {
        return _context.Users.Find(id);
    }
    
    public void InsertUser(UserEntity user)
    {
        DateTime date = DateTime.Now;
        user.UpdateCreatedAt(date);
        
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(UserEntity user)
    {
        DateTime date = DateTime.Now;
        user.UpdateUpdatedAt(date);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public bool DeleteUser(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            DateTime date = DateTime.Now;
            user.UpdateDeletedAt(date);
            user.UpdateActive(false);
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
    
    public UserEntity? GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(
            u => u.Email == email && u.Active == true);
    }
}
