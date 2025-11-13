using Azure.Storage.Blobs.Models;
using Infrastructure.BlobRepository.Interface;
using MediatR;

namespace Application.BlobCQ.Command.Handler
{
    public class AzureUploadPhotoCommandHandler : IRequestHandler<AzureUploadPhotoCommand, Guid>
    {
        private readonly IBlobRepository _blobRepository;
        public AzureUploadPhotoCommandHandler(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }
        public async Task<Guid> Handle(AzureUploadPhotoCommand request, CancellationToken cancellationToken)
        {
            var fileId = Guid.NewGuid();
            var blobClient = _blobRepository.AddBlobClient(fileId);

            await blobClient.UploadAsync(
                request.Stream,
                new BlobHttpHeaders {ContentType = request.ContentType },
                cancellationToken: request.Token
                );

            return fileId;
        }
    }
}
