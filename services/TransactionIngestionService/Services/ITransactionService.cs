using TransactionIngestionService.Models;

namespace TransactionIngestionService.Services;

public interface ITransactionService
{
    TransactionResponse IngestTransaction(CreateTransactionRequest request);
}
