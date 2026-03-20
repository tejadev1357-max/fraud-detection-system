using Microsoft.AspNetCore.Mvc;
using TransactionIngestionService.Models;
using TransactionIngestionService.Services;

namespace TransactionIngestionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] CreateTransactionRequest request)
    {
        var response = _transactionService.IngestTransaction(request);
        return Accepted(response);
    }
}
