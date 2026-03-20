namespace SharedKernel.Events;

public class FraudDetectedEvent
{
    public Guid TransactionId { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
    public double? MlFraudScore { get; set; }
    public List<string> TriggeredRules { get; set; } = new();
    public DateTime DetectedAt { get; set; }
}
