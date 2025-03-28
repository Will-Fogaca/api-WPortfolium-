using WillPortfolio_Api.Domain.Dtos;

namespace WillPortfolio_Api.Services.Interfaces;

public interface IUserService
{
    UserDto.UserDTO? GetUserById(Guid id);
    UserDto.UserDTO CreateUser(UserDto.CreateUserDTO userDto);
    void UpdateUser(Guid id, UserDto.UpdateUserDTO userDto); 
    bool DeleteUser(Guid id);
}
