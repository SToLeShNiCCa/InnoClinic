using Azure.Storage.Blobs;

namespace Infrastructure.BlobRepository.Interface
{
    public interface IBlobRepository
    {
        BlobClient AddBlobClient(Guid fileId);
    }
}
