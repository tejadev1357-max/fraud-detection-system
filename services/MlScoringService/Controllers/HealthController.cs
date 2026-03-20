using Microsoft.AspNetCore.Mvc;

namespace MlScoringService.Controllers;

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
            Service = "MlScoringService",
            Timestamp = DateTime.UtcNow
        });
    }
}
