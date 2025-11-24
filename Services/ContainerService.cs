
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureBlobProject.Services
{
    public class ContainerService : IContainerService
    {
        private readonly BlobServiceClient _blobClient;
        public ContainerService(BlobServiceClient blobClient)
        { 
          _blobClient = blobClient;
        }
        public async Task CreateContainer(string containerName)
        {
           BlobContainerClient blobContainerCilent =  _blobClient.GetBlobContainerClient(containerName);
              await blobContainerCilent.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
        }

        public async Task DeleteContainer(string containerName)
        {
            BlobContainerClient blobContainerCilent = _blobClient.GetBlobContainerClient(containerName);
            await blobContainerCilent.DeleteIfExistsAsync();
        
        }

        public async Task<List<string>> GetAllContainer()
        {
           List<string> containerName = new List<string>();    
              await foreach (BlobContainerItem blobContainerItem in _blobClient.GetBlobContainersAsync())
              {
                containerName.Add(blobContainerItem.Name);
              }

              return containerName;
        }

        public Task<List<string>> GetAllContainerAndBlob()
        {
            throw new NotImplementedException();
        }
    }
}
