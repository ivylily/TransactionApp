using System.ComponentModel;
using TransactionApp.Domain.Extensions;

namespace TransactionApp.Domain.Services.Communication
{
    public class SubmitTransactionResponse : BaseResponse
    {
        public ETransactionError? TransactionError { get; private set; }

        public SubmitTransactionResponse(bool success, string message) : base(success, message)
        {
        }
        public SubmitTransactionResponse(ETransactionError error) 
        : base(false, error.ToDescriptionString())
        {
            TransactionError = error;
        }

        public SubmitTransactionResponse(ETransactionError error, string message)
        : base(false, message)
        {
            TransactionError = error;
        }

        public enum ETransactionError
        {
            [Description("Invalid Client")]
            InvalidClient,
            [Description("Max Transactions Reached")]
            MaxTransactionQuantityReached,
            [Description("Insuficient Funds")]
            InsuficientFunds
        }
    }
}
