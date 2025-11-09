using Azure.Storage.Blobs;

namespace ABC_Retail_CloudApp.Services
{
    public class AzureBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobService(IConfiguration config)
        {
            string conn = config.GetConnectionString("AzureStorage")!;
            _blobServiceClient = new BlobServiceClient(conn);
        }

        public async Task<string> UploadFileAsync(string containerName, IFormFile file)
        {
            try
            {
                var container = _blobServiceClient.GetBlobContainerClient(containerName);
                await container.CreateIfNotExistsAsync();

                var blob = container.GetBlobClient(file.FileName);
                await blob.UploadAsync(file.OpenReadStream(), overwrite: true);

                // ✅ Always return the Blob URL on success
                return blob.Uri.ToString();
            }
            catch (Exception ex)
            {
                // Log the error if needed
                Console.WriteLine($"Error uploading blob: {ex.Message}");

                // ✅ Return an empty string (or you can throw, but empty keeps it safe)
                return string.Empty;
            }
        }

    }
}
