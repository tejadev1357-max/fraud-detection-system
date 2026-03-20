using MlScoringService.Models;

namespace MlScoringService.Services;

public class ScoringService : IScoringService
{
    private readonly ILogger<ScoringService> _logger;

    public ScoringService(ILogger<ScoringService> logger)
    {
        _logger = logger;
    }

    public ScoreResponse Score(ScoreRequest request)
    {
        var score = Random.Shared.NextDouble();

        var riskCategory = score switch
        {
            < 0.3 => "Low",
            < 0.7 => "Medium",
            _ => "High"
        };

        _logger.LogInformation(
            "ML score for account {AccountId}: {Score} ({RiskCategory})",
            request.AccountId, score, riskCategory);

        return new ScoreResponse
        {
            FraudScore = Math.Round(score, 4),
            RiskCategory = riskCategory,
            ScoredAt = DateTime.UtcNow
        };
    }
}
