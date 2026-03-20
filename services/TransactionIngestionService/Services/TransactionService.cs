using System.Net.Http.Json;
using TransactionIngestionService.Models;

namespace TransactionIngestionService.Services;

public class TransactionService : ITransactionService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TransactionService> _logger;

    public TransactionService(HttpClient httpClient, ILogger<TransactionService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<TransactionResponse> IngestTransactionAsync(CreateTransactionRequest request)
    {
        var transactionId = Guid.NewGuid();

        _logger.LogInformation(
            "Transaction {TransactionId} ingested for account {AccountId}, amount {Amount} {Currency}",
            transactionId, request.AccountId, request.Amount, request.Currency);

        var evaluateRequest = new
        {
            request.AccountId,
            request.Amount,
            request.Currency,
            request.MerchantName,
            request.TransactionType,
            request.SourceIp,
            request.Location
        };

        RuleEvaluationResult? ruleResult = null;

        try
        {
            var response = await _httpClient.PostAsJsonAsync("/rules/evaluate", evaluateRequest);
            response.EnsureSuccessStatusCode();
            ruleResult = await response.Content.ReadFromJsonAsync<RuleEvaluationResult>();

            _logger.LogInformation(
                "Rule evaluation for {TransactionId}: IsFraudulent={IsFraudulent}, RiskLevel={RiskLevel}",
                transactionId, ruleResult?.IsFraudulent, ruleResult?.RiskLevel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to evaluate rules for transaction {TransactionId}", transactionId);
        }

        return new TransactionResponse
        {
            TransactionId = transactionId,
            Status = ruleResult?.IsFraudulent == true ? "Flagged" : "Accepted",
            ReceivedAt = DateTime.UtcNow,
            RuleEvaluation = ruleResult
        };
    }
}
