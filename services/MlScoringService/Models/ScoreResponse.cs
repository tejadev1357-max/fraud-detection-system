namespace MlScoringService.Models;

public class ScoreResponse
{
    public double FraudScore { get; set; }
    public string RiskCategory { get; set; } = string.Empty;
    public DateTime ScoredAt { get; set; }
}
