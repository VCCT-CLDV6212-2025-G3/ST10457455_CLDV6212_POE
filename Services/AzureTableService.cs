using Azure.Data.Tables;

namespace ABC_Retail_CloudApp.Services
{
    public class AzureTableService
    {
        private readonly TableServiceClient _tableServiceClient;

        public AzureTableService(IConfiguration config)
        {
            string conn = config.GetConnectionString("AzureStorage")!;
            _tableServiceClient = new TableServiceClient(conn);
        }

        public async Task<TableClient> GetTableClientAsync(string tableName)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync();
            return tableClient;
        }
    }
}
