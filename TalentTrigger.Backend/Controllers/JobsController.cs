using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TalentTrigger.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly ILogger<JobsController> _logger;

    public JobsController(ILogger<JobsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new
        {
            message = "Job scraping service is running",
            timestamp = DateTime.UtcNow,
            status = "active"
        });
    }

    [HttpPost("trigger-scraping")]
    public async Task<IActionResult> TriggerScraping()
    {
        _logger.LogInformation("Manual job scraping triggered at {time}", DateTime.UtcNow);
        
        // TODO: Implement actual job scraping logic here
        await Task.Delay(1000); // Simulate some work
        
        return Ok(new
        {
            message = "Job scraping triggered successfully",
            timestamp = DateTime.UtcNow
        });
    }
} 