using Microsoft.AspNetCore.Mvc;
using RuleEngineService.Models;
using RuleEngineService.Services;

namespace RuleEngineService.Controllers;

[ApiController]
[Route("[controller]")]
public class RulesController : ControllerBase
{
    private readonly IRuleEngineService _ruleEngineService;

    public RulesController(IRuleEngineService ruleEngineService)
    {
        _ruleEngineService = ruleEngineService;
    }

    [HttpPost("evaluate")]
    [ProducesResponseType(typeof(EvaluateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Evaluate([FromBody] EvaluateRequest request)
    {
        var result = await _ruleEngineService.EvaluateAsync(request);
        return Ok(result);
    }
}
