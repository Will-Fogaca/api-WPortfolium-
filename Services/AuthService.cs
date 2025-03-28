using Microsoft.AspNetCore.Identity;
using WillPortfolio_Api.Domain.Dtos;
using WillPortfolio_Api.Repositories.Interfaces;
using WillPortfolio_Api.Services.Interfaces;

namespace WillPortfolio_Api.Services;

public class AuthService :  IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService; 
    
    public AuthService(IUserRepository userRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public AuthResponseDto Authenticate(LoginRequestDto loginDto)
    {
        //Busco o usuário pelo email
        var user = _userRepository.GetByEmail(loginDto.Email);

        //Se não encontrar, as credenciais estão inválidas
        if (user == null)
            throw new UnauthorizedAccessException("Credenciais inválidas");

        //Inicio um objeto do tipo PasswordHasher para comparar a senha
        var passwordHasher = new PasswordHasher<object>();
        
        //Faço a validação validando a senha que está no banco o mesmo hash que foi gravado
        var result = passwordHasher.VerifyHashedPassword(null, user.Password, loginDto.Password);

        //Caso retorna incorreto, lança uma exceção, senão gera um token
        if (result == PasswordVerificationResult.Failed)
            throw new UnauthorizedAccessException("Credenciais inválidas");

        var token = _tokenService.GenerateToken(user);

        return new AuthResponseDto(token, user.Name, user.Email);
    }
}