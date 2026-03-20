using RuleEngineService.Models;

namespace RuleEngineService.Services;

public interface IRuleEngineService
{
    Task<EvaluateResponse> EvaluateAsync(EvaluateRequest request);
}
