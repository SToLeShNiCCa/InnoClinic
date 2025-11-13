using Azure.Storage.Blobs;
using Infrastructure.BLOBRepository.Interface;

namespace Infrastructure.BLOBRepository.Implementation
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
