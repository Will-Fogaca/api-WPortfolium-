using WillPortfolio_Api.Domain.Entities;

namespace WillPortfolio_Api.Repositories.Interfaces;

public interface IUserRepository
{
    UserEntity? GetUserById(Guid id);
    void InsertUser(UserEntity user);
    void UpdateUser(UserEntity user);
    bool DeleteUser(Guid id);
}