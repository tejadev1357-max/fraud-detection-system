namespace SharedKernel.Events;

public class TransactionEvent
{
    public Guid TransactionId { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string MerchantName { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;
    public string SourceIp { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
