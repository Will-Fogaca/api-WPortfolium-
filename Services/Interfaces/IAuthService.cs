using WillPortfolio_Api.Domain.Dtos;

namespace WillPortfolio_Api.Services.Interfaces;

public interface IAuthService
{
    AuthResponseDto Authenticate(LoginRequestDto loginDto);
}