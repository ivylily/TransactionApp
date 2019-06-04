using System.Threading.Tasks;
using TransactionApp.Domain.Configuration;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Repositories;
using TransactionApp.Domain.Services;
using TransactionApp.Domain.Services.Communication;
using static TransactionApp.Domain.Services.Communication.SubmitTransactionResponse;

namespace TransactionApp.BL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAppConfiguration _appConfiguration;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IAppConfiguration appConfiguration, IClientRepository clientRepository, ITransactionRepository transactionRepository)
        {
            _clientRepository = clientRepository;
            _appConfiguration = appConfiguration;
            _transactionRepository = transactionRepository;
        }

        public async Task<SubmitTransactionResponse> SubmitTransactionAsync(Transaction transaction)
        {
            if (transaction == null)
                return new SubmitTransactionResponse(true, string.Empty);

            if (transaction.Amount >= _appConfiguration.MaxAmountPerTransaction)
                return new SubmitTransactionResponse(ETransactionError.MaxTransactionQuantityReached);

            var existingClient = await _clientRepository.FindByIdAsync(transaction.ClientId);
            if (existingClient == null)
                return new SubmitTransactionResponse(ETransactionError.InvalidClient, $"Client {transaction.ClientId} does not exist.");
           
            switch (transaction.TransactionType)
            {
                case ETransactionType.Deposit:
                    return await Deposit(transaction, existingClient);
                case ETransactionType.Transfer:
                    return await Transfer(transaction, existingClient);
                case ETransactionType.Withdrawal:
                    return await Withdrawal(transaction, existingClient);
                default:
                    return new SubmitTransactionResponse(false, "Invalid transaction type.");
            }
        }

        private async Task<SubmitTransactionResponse> Deposit(Transaction tran, Client client)
        {
            client.CurrentAmount += tran.Amount;
            _clientRepository.Update(client);
            await _transactionRepository.AddAsync(tran);

            return new SubmitTransactionResponse(true, "Deposit completed");
        }

        private async Task<SubmitTransactionResponse> Transfer(Transaction tran, Client client)
        {
            if (!await CheckClientBalance(tran.ClientId, tran.Amount))
                return new SubmitTransactionResponse(ETransactionError.InsuficientFunds);

            var merchandClient = await _clientRepository.FindByIdAsync(tran.MerchandClientId);
            if (merchandClient == null)
               return new SubmitTransactionResponse(ETransactionError.InvalidClient, $"Client {tran.MerchandClientId} does not exist.");

            client.CurrentAmount -= tran.Amount;
            merchandClient.CurrentAmount += tran.Amount;
            _clientRepository.Update(client);
            _clientRepository.Update(merchandClient);
            await _transactionRepository.AddAsync(tran);

            return new SubmitTransactionResponse(true, "Tranfer completed"); ;
        }

        private async Task<SubmitTransactionResponse> Withdrawal(Transaction tran, Client client)
        {
            if (!await CheckClientBalance(tran.ClientId, tran.Amount))
                return new SubmitTransactionResponse(ETransactionError.InsuficientFunds);

            client.CurrentAmount -= tran.Amount;
            _clientRepository.Update(client);
            await _transactionRepository.AddAsync(tran);

            return new SubmitTransactionResponse(true, "Withdrawal completed");
        }

        private async Task<bool> CheckClientBalance(long clientId, decimal neededAmount)
        {
            var balance = await _clientRepository.GetAccountBalanceAsync(clientId);
            return balance >= neededAmount;
        }
    }
}
