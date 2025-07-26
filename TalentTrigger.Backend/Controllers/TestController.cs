using Microsoft.AspNetCore.Mvc;

namespace TalentTrigger.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("TalentTrigger is running ✅");
    }
} 