using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionPostRequest transaction)
        {
            await Task.Run(() => _transactionService.CreateTransaction(transaction));
            return Created("CreateTransaction", transaction);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(await Task.FromResult(_transactionService.GetAllTransactions()));
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetCount()
        {
            return Ok(await Task.FromResult(_transactionService.GetTransactionsCount()));
        }
    }
}