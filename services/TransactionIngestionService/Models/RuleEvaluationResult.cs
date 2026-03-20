namespace TransactionIngestionService.Models;

public class RuleEvaluationResult
{
    public bool IsFraudulent { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
    public List<string> TriggeredRules { get; set; } = new();
    public DateTime EvaluatedAt { get; set; }
}
