namespace Taxually.TechnicalTest.DataAccess.Clients.Contracts
{
    public interface ITaxuallyHttpClient
    {
        Task PostAsync<TRequest>(string url, TRequest request);
    }
}