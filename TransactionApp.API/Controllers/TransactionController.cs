using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Services;
using TransactionApp.Domain.Services.Communication;

namespace TransactionApp.API.Controllers
{
    [Route("api/core")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IClientService _clientService;

        TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<decimal> GetBalanceAsync(long accountId)
        {
            return await _clientService.GetBalanceAsync(accountId);
        }

        // POST api/values
        [HttpPost]
        public async Task<SubmitTransactionResponse> SubmitTransactionAsync(Transaction transaction)
        {
            return await _transactionService.SubmitTransactionAsync(transaction);
        }
    }
}
