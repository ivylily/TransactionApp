using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionApp.Domain.Services;

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
            var balance = await _clientService.GetBalanceAsync(accountId);
            return balance;
        }

        // POST api/values
        [HttpPost]
        public void SubmitTransaction([FromBody] string value)
        {
        }
    }
}
