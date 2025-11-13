using Azure;
using Azure.Data.Tables;

namespace ABC_Retail_CloudApp.Models
{
    public class CustomerEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = "Customers";
        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
