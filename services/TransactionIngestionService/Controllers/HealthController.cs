using Microsoft.AspNetCore.Mvc;

namespace TransactionIngestionService.Controllers;

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
            Service = "TransactionIngestionService",
            Timestamp = DateTime.UtcNow
        });
    }
}
