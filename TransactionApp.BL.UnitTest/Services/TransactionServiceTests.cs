using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TransactionApp.Domain.Configuration;
using TransactionApp.Domain.Models;
using TransactionApp.Domain.Repositories;
using TransactionApp.Domain.Services;
using static TransactionApp.Domain.Services.Communication.SubmitTransactionResponse;

namespace TransactionApp.BL.Tests.Services
{
    [TestFixture]
    public class TransactionServiceTests
    {
        private ITransactionService _transactionService;
        
        [TestCase(1, 500, 400, ETransactionType.Withdrawal)]
        [TestCase(1, 1, 0, ETransactionType.Transfer)]
        [TestCase(1, 10000, 400, ETransactionType.Withdrawal)]
        [TestCase(1, 600, 400, ETransactionType.Transfer)]
        public void InsufficientFundsError(int userId, decimal amount, decimal currentAmount, ETransactionType transactionType)
        {
            #region fixture setup
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockClientRepository = new Mock<IClientRepository>();

            var appConfig = new AppConfiguration(20000);

            mockClientRepository.Setup(p => p.FindByIdAsync(userId)).ReturnsAsync(new Client() { ClientId = userId, CurrentAmount = currentAmount });
            mockClientRepository.Setup(p => p.GetAccountBalanceAsync(userId)).ReturnsAsync(currentAmount);
            #endregion

            _transactionService = new BL.Services.TransactionService(appConfig, mockClientRepository.Object, fixture.Freeze<ITransactionRepository>());

            var result = _transactionService.SubmitTransactionAsync(new Transaction() { ClientId = userId, Amount = amount, TransactionType = transactionType });

            Assert.AreEqual(result.Result.TransactionError, ETransactionError.InsuficientFunds);
        }

        [TestCase(1, 40000,2000)]
        [TestCase(1, 40000, 3000)]
        [TestCase(1, 0, 0)]
        public void DailyLimitReachedError(int clientId, int amount, int maxAmountTransfer)
        {
            #region fixture setup
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockClientRepository = new Mock<IClientRepository>();

            var appConfig = new AppConfiguration(maxAmountTransfer);

            mockClientRepository.Setup(p => p.FindByIdAsync(clientId)).ReturnsAsync(new Client() { ClientId = clientId });
            #endregion

            _transactionService = new BL.Services.TransactionService(appConfig, mockClientRepository.Object, fixture.Freeze<ITransactionRepository>());

            var result = _transactionService.SubmitTransactionAsync(new Transaction() { ClientId = clientId, Amount = amount});

            Assert.AreEqual(result.Result.TransactionError, ETransactionError.InsuficientFunds);
        }

        private List<Client> GetSampleClients()
        {
            return new List<Client>
            {
                new Client() { ClientId = 1, ClientName = "Juan Fulano", BankId = 1, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 400000 },
                new Client() { ClientId = 2, ClientName = "Maria Fulano", BankId = 1, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 245009 },
                new Client() { ClientId = 3, ClientName = "Betty Mengano", BankId = 2, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 100000 },
                new Client() { ClientId = 4, ClientName = "Pedro Vegano", BankId = 2, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 300000 },
                new Client() { ClientId = 5, ClientName = "Alix Mengano", BankId = 3, CreatedOn = DateTime.UtcNow, Status = "A", CurrentAmount = 25000 }
        };
        }
    }
}
