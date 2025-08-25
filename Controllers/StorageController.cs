using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Storage.Files.Shares;
using Microsoft.AspNetCore.Mvc;

namespace ABCRetailWebApp.Controllers
{
    public class StorageController : Controller
    {
        private readonly string connectionString;

        public StorageController(IConfiguration configuration)
        {
            // Get the Azure Storage connection string from appsettings.json
            connectionString = configuration.GetConnectionString("AzureStorage")!;
        }

        // -----------------------
        // 1️⃣ Table Storage: Customers
        // -----------------------
        public IActionResult AddCustomer()
        {
            var tableClient = new TableClient(connectionString, "Customers");
            tableClient.CreateIfNotExists();

            var entity = new TableEntity("CustomerPartition", Guid.NewGuid().ToString())
            {
                { "FirstName", "James" },
                { "LastName", "Baker" },
                { "Email", "james@email.com" }
            };

            tableClient.AddEntity(entity);

            return Content("✅ Table Storage test: Customer added successfully!");
        }

        // -----------------------
        // 2️⃣ Table Storage: Products
        // -----------------------
        public IActionResult AddProduct()
        {
            var tableClient = new TableClient(connectionString, "Products");
            tableClient.CreateIfNotExists();

            var entity = new TableEntity("ProductPartition", Guid.NewGuid().ToString())
            {
                { "ProductName", "Laptop" },
                { "Category", "Electronics" },
                { "Price", 1200 }
            };

            tableClient.AddEntity(entity);

            return Content("✅ Table Storage test: Product added successfully!");
        }

        // -----------------------
        // 3️⃣ Blob Storage: Upload File
        // -----------------------
        [HttpPost]
        public IActionResult UploadBlob(IFormFile file)
        {
            var blobClient = new BlobContainerClient(connectionString, "productimages");
            blobClient.CreateIfNotExists();

            var blob = blobClient.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();
            blob.Upload(stream, true);

            return Content($"✅ Blob Storage test: {file.FileName} uploaded successfully!");
        }

        // -----------------------
        // 4️⃣ Queue Storage: Send Message
        // -----------------------
        public IActionResult SendQueueMessage()
        {
            var queueClient = new QueueClient(connectionString, "ordersqueue");
            queueClient.CreateIfNotExists();
            queueClient.SendMessage("Test order message");

            return Content("✅ Queue Storage test: Message sent successfully!");
        }

        // -----------------------
        // 5️⃣ File Storage: Upload File
        // -----------------------
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var shareClient = new ShareClient(connectionString, "contracts");
            shareClient.CreateIfNotExists();

            var directory = shareClient.GetRootDirectoryClient();
            var fileClient = directory.GetFileClient(file.FileName);

            using var stream = file.OpenReadStream();
            fileClient.Create(file.Length);
            fileClient.UploadRange(new Azure.HttpRange(0, file.Length), stream);

            return Content($"✅ File Storage test: {file.FileName} uploaded successfully!");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
