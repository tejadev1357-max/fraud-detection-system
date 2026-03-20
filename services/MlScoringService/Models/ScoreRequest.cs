using System.ComponentModel.DataAnnotations;

namespace MlScoringService.Models;

public class ScoreRequest
{
    [Required]
    public string AccountId { get; set; } = string.Empty;

    [Required]
    public decimal Amount { get; set; }

    public string Currency { get; set; } = "USD";

    public string MerchantName { get; set; } = string.Empty;

    public string TransactionType { get; set; } = string.Empty;

    public string SourceIp { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
}
