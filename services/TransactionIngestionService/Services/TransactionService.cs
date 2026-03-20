using TransactionIngestionService.Models;

namespace TransactionIngestionService.Services;

public class TransactionService : ITransactionService
{
    private readonly ILogger<TransactionService> _logger;

    public TransactionService(ILogger<TransactionService> logger)
    {
        _logger = logger;
    }

    public TransactionResponse IngestTransaction(CreateTransactionRequest request)
    {
        var transactionId = Guid.NewGuid();

        _logger.LogInformation(
            "Transaction {TransactionId} ingested for account {AccountId}, amount {Amount} {Currency}",
            transactionId, request.AccountId, request.Amount, request.Currency);

        return new TransactionResponse
        {
            TransactionId = transactionId,
            Status = "Accepted",
            ReceivedAt = DateTime.UtcNow
        };
    }
}
