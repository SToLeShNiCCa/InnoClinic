using Azure.Storage.Blobs;
using Infrastructure.BlobRepository.Interface;

namespace Infrastructure.BlobRepository.Implementation
{
    public class BlobRepository(BlobServiceClient blobServiceClient) : IBlobRepository
    {
        private const string ContainerName = "photoes";
        public BlobClient AddBlobClient(Guid fileId)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            return blobClient;
        }
    }
}
