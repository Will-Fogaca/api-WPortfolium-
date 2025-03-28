namespace WillPortfolio_Api.Domain.Dtos;

public class AuthResponseDto
{
    public string Token { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public AuthResponseDto(string token, string userName, string email)
    {
        Token = token;
        UserName = userName;
        Email = email;
    }
}