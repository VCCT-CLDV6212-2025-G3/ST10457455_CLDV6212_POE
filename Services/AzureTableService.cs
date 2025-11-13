using Azure.Data.Tables;

namespace ABC_Retail_CloudApp.Services
{
    public class AzureTableService
    {
        private readonly TableServiceClient _tableServiceClient;

        public AzureTableService(IConfiguration config)
        {
            // Get the Storage connection string
            string connectionString = config.GetConnectionString("AzureStorageConnection")
                ?? throw new Exception("AzureStorageConnection not found in appsettings.json");

            _tableServiceClient = new TableServiceClient(connectionString);
        }

        // Returns a TableClient for any table
        public async Task<TableClient> GetTableClientAsync(string tableName)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);

            // Create table if it doesn't exist
            await tableClient.CreateIfNotExistsAsync();

            return tableClient;
        }
    }
}
