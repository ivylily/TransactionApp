using System.ComponentModel;

namespace TransactionApp.Domain.Models
{
    public enum ETransactionType : byte
    {
        [Description("W")]
        Withdrawal = 1,

        [Description("D")]
        Deposit = 2,

        [Description("T")]
        Transfer = 3
    }
}
