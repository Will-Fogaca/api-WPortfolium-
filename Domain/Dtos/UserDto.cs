namespace WillPortfolio_Api.Domain.Dtos;

public class UserDto
{
    public class UserDTO
    { 
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserDTO(Guid userId, string userName, string userEmail)
        {
            this.Id = userId;
            this.Name = userName;
            this.Email = userEmail;
        }
    }

    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    
    public record UpdateUserDTO(string Name, string Email);
}