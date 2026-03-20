namespace TransactionIngestionService.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string MerchantName { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string SourceIp { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
