namespace RuleEngineService.Models;

public class EvaluateResponse
{
    public bool IsFraudulent { get; set; }
    public string RiskLevel { get; set; } = "Low";
    public List<string> TriggeredRules { get; set; } = new();
    public DateTime EvaluatedAt { get; set; }
}
