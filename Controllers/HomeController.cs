
using Microsoft.AspNetCore.Mvc;

namespace WillPortfolio_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet("Index")]
    public IActionResult Index()
    {
        return Ok("Api Funcionando");
    }
    
    
}