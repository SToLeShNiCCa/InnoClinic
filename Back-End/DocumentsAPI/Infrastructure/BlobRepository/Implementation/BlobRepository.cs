using Azure.Storage.Blobs;
using Infrastructure.BLOBRepository.Interface;
using Microsoft.Extensions.Options;

namespace Infrastructure.BLOBRepository.Implementation
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobContainerClient _containerClient;
        public BlobRepository(IOptions<DbSettings.AzureDatabaseSettings> _settings)
        {
            var blobServiceClient = new BlobServiceClient(_settings.Value.AzureBlobStorage);
            var containerClient = blobServiceClient.GetBlobContainerClient(_settings.Value.AzureBlobContainer);

            _containerClient = containerClient;
        }
        public BlobClient AddBlobClient(Guid fileId)
        {
            var blobClient = _containerClient.GetBlobClient(fileId.ToString());

            return blobClient;
        }
    }
}
