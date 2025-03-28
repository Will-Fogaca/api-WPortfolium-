using Microsoft.AspNetCore.Mvc;
using WillPortfolio_Api.Domain.Dtos;
using WillPortfolio_Api.Domain.Entities;
using WillPortfolio_Api.Services;
using WillPortfolio_Api.Services.Interfaces;

namespace WillPortfolio_Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
    
    [HttpPost]
    public IActionResult InsertUser([FromBody] UserDto.CreateUserDTO userDto)
    {
        var newUser = _userService.CreateUser(userDto);
        return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UserDto.UpdateUserDTO userDto)
    {
        try
        {
            _userService.UpdateUser(id, userDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        if (!_userService.DeleteUser(id))
            return NotFound();

        return NoContent();
    }
}