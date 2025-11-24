
using Azure.Storage.Blobs;
using AzureBlobProject.Models;

namespace AzureBlobProject.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;
        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }
        public async Task<bool> CreateBlob(string name, IFormFile file, string containerName, BlobModel blobModel)
        {
            BlobContainerClient blobContainerCilent = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerCilent.GetBlobClient(name);

            var httpHeaders = new Azure.Storage.Blobs.Models.BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };
            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            BlobContainerClient blobContainerCilent = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerCilent.GetBlobClient(name);

            return await blobClient.DeleteIfExistsAsync();

        }

        public async Task<List<string>> GetAllBlobs(string containerName)
        {
            BlobContainerClient blobContainerCilent = _blobClient.GetBlobContainerClient(containerName);
            var blobs = blobContainerCilent.GetBlobsAsync();
            List<string> blobNames = new List<string>();
            await foreach (var blobItem in blobs)
            {
                blobNames.Add(blobItem.Name);
            }
            return blobNames;
        }

        public async Task<List<BlobModel>> GetAllBlobsWithUri(string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetBlob(string name, string containerName)
        {
            BlobContainerClient blobContainerCilent = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerCilent.GetBlobClient(name);
            if (blobClient != null)
            {
                return blobClient.Uri.AbsoluteUri;

            }
            return "";

        }
    }
}
