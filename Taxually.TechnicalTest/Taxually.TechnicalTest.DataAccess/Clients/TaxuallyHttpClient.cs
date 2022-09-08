using Taxually.TechnicalTest.DataAccess.Clients.Contracts;

namespace Taxually.TechnicalTest.DataAccess.Clients
{
    public class TaxuallyHttpClient : ITaxuallyHttpClient
    {
        public Task PostAsync<TRequest>(string url, TRequest request)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
