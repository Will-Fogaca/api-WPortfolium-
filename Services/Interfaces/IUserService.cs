using WillPortfolio_Api.Domain.Dtos;

namespace WillPortfolio_Api.Services.Interfaces;

public interface IUserService
{
    UserDTO? GetUserById(Guid id);
    UserDTO CreateUser(CreateUserDTO userDto);
    void UpdateUser(Guid id, UpdateUserDTO userDto); 
    bool DeleteUser(Guid id);
}
