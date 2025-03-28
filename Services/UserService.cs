using WillPortfolio_Api.Domain.Dtos;
using WillPortfolio_Api.Domain.Entities;
using WillPortfolio_Api.Repositories.Interfaces;
using WillPortfolio_Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;



public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    

    public UserDto.UserDTO? GetUserById(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        return user == null ? null : new UserDto.UserDTO(user.Id, user.Name, user.Email);
    }

    public UserDto.UserDTO CreateUser(UserDto.CreateUserDTO userDto)
    {
        var passwordHasher = new PasswordHasher<UserEntity>();

        var newUser = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
            Email = userDto.Email,
        };

        newUser.Password = passwordHasher.HashPassword(newUser, userDto.Password);

        _userRepository.InsertUser(newUser);

        return new UserDto.UserDTO(newUser.Id, newUser.Name, newUser.Email);
    }



    public void UpdateUser(Guid id, UserDto.UpdateUserDTO userDto)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        user.Name = userDto.Name;
        user.Email = userDto.Email;

        _userRepository.UpdateUser(user);
    }

    public bool DeleteUser(Guid id)
    {
        return _userRepository.DeleteUser(id);
    }

}