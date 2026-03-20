using System.ComponentModel.DataAnnotations;

namespace TransactionIngestionService.Models;

public class CreateTransactionRequest
{
    [Required]
    public string AccountId { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    public string Currency { get; set; } = "USD";

    [Required]
    public string MerchantName { get; set; } = string.Empty;

    [Required]
    public string TransactionType { get; set; } = string.Empty;

    public string SourceIp { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
}
