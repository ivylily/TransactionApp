using System;
using System.Collections.Generic;

namespace TransactionApp.Domain.Models
{
    public class Bank
    {
        public long BankId { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public IList<Client> Clients { get; set; } = new List<Client>();
    }
}
