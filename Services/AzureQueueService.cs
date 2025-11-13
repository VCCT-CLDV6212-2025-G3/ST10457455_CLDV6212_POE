using Azure.Storage.Queues;

namespace ABC_Retail_CloudApp.Services
{
    public class AzureQueueService
    {
        private readonly QueueServiceClient _queueServiceClient;

        public AzureQueueService(IConfiguration config)
        {
            string conn = config.GetConnectionString("AzureStorageConnection")!;
            _queueServiceClient = new QueueServiceClient(conn);
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            var queue = _queueServiceClient.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();
            await queue.SendMessageAsync(message);
        }
    }
}
