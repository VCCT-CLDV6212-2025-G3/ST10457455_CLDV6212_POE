using Azure.Storage.Files.Shares;

namespace ABC_Retail_CloudApp.Services
{
    public class AzureFileService
    {
        private readonly ShareServiceClient _shareServiceClient;

        public AzureFileService(IConfiguration config)
        {
            string conn = config.GetConnectionString("AzureStorageConnection")!;
            _shareServiceClient = new ShareServiceClient(conn);
        }

        public async Task UploadFileAsync(IFormFile file, string shareName)
        {
            var share = _shareServiceClient.GetShareClient(shareName);
            await share.CreateIfNotExistsAsync();

            var directory = share.GetRootDirectoryClient();
            var fileClient = directory.GetFileClient(file.FileName);

            await fileClient.CreateAsync(file.Length);
            await fileClient.UploadAsync(file.OpenReadStream());
        }
    }
}
