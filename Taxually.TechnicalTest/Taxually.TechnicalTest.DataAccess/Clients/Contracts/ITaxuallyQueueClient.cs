namespace Taxually.TechnicalTest.DataAccess.Clients.Contracts
{
    public interface ITaxuallyQueueClient
    {
        Task EnqueueAsync<TPayload>(string queueName, TPayload payload);
    }
}