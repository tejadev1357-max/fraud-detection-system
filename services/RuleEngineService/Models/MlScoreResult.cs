namespace RuleEngineService.Models;

public class MlScoreResult
{
    public double FraudScore { get; set; }
    public string RiskCategory { get; set; } = string.Empty;
    public DateTime ScoredAt { get; set; }
}
