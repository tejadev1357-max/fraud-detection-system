namespace TransactionIngestionService.Models;

public class TransactionResponse
{
    public Guid TransactionId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime ReceivedAt { get; set; }
    public RuleEvaluationResult? RuleEvaluation { get; set; }
}
