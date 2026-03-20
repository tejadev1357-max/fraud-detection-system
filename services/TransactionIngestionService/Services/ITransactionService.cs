using TransactionIngestionService.Models;

namespace TransactionIngestionService.Services;

public interface ITransactionService
{
    Task<TransactionResponse> IngestTransactionAsync(CreateTransactionRequest request);
}
