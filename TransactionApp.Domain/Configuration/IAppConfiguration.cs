namespace TransactionApp.Domain.Configuration
{
    public interface IAppConfiguration
    {
        int MaxAmountPerTransaction { get; }
    }

    public class AppConfiguration : IAppConfiguration
    {
        public AppConfiguration(int maxAmountPerTransactio)
        {
            MaxAmountPerTransaction = maxAmountPerTransactio;
        }
        public int MaxAmountPerTransaction { get; private set; }
    }
}
