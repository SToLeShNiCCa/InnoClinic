using Application.BlobCQ.BlobPhotoCQ.Command;
using Azure.Storage.Blobs.Models;
using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Command.Handler
{
    public class AzureUploadPhotoCommandHandler : IRequestHandler<AzureUploadPhotoCommand, Guid>
    {
        private readonly IBlobRepository _blobRepository;
        public AzureUploadPhotoCommandHandler(IBlobRepository blobRepository)
        {
         _blobRepository = blobRepository;
        }
        public async Task<Guid> Handle(AzureUploadPhotoCommand request, CancellationToken token)
        {
            var fileId = Guid.NewGuid();
            var blobClient = _blobRepository.AddBlobClient(fileId);

            await blobClient.UploadAsync(
                request.Stream,
                new BlobHttpHeaders {ContentType = request.ContentType },
                cancellationToken: token
                );

            return fileId;
        }
    }
}
