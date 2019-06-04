using System;

namespace TransactionApp.Domain.Models
{
    public class Transaction
    {
        public long TransactionId { get; set; }                
        public long MerchandClientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }        
        public ETransactionType TransactionType { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}
