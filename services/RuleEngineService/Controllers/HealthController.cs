using Microsoft.AspNetCore.Mvc;

namespace RuleEngineService.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            Service = "RuleEngineService",
            Timestamp = DateTime.UtcNow
        });
    }
}
