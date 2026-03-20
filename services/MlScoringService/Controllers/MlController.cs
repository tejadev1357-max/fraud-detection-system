using Microsoft.AspNetCore.Mvc;
using MlScoringService.Models;
using MlScoringService.Services;

namespace MlScoringService.Controllers;

[ApiController]
[Route("[controller]")]
public class MlController : ControllerBase
{
    private readonly IScoringService _scoringService;

    public MlController(IScoringService scoringService)
    {
        _scoringService = scoringService;
    }

    [HttpPost("score")]
    [ProducesResponseType(typeof(ScoreResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Score([FromBody] ScoreRequest request)
    {
        var result = _scoringService.Score(request);
        return Ok(result);
    }
}
