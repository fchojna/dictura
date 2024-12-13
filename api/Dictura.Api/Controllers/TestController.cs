using Microsoft.AspNetCore.Mvc;

namespace Dictura.Api.Controllers;

[Route("[controller]")]
public class TestController : Controller
{
    [HttpGet("echo")]
    public IActionResult Echo()
    {
        return Ok("echo");
    }
}