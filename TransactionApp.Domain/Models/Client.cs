using System;
using System.Collections.Generic;

namespace TransactionApp.Domain.Models
{
    public class Client
    {
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }        
        public decimal CurrentAmount { get; set; }

        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();

        public long BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
