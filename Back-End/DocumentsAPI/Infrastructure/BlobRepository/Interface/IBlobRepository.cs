using Azure.Storage.Blobs;

namespace Infrastructure.BLOBRepository.Interface
{
    public interface IBlobRepository
    {
        BlobClient AddBlobClient(Guid fileId);
    }
}
