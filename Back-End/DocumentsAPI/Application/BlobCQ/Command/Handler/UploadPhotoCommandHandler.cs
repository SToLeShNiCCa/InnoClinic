using Azure.Storage.Blobs.Models;
using Infrastructure.BlobRepository.Interface;
using MediatR;

namespace Application.BlobCQ.Command.Handler
{
    public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand, Guid>
    {
        private readonly IBlobRepository _blobRepository;
        public UploadPhotoCommandHandler(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }
        public async Task<Guid> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
        {
            var fileId = Guid.NewGuid();
            var blobClient = _blobRepository.AddBlobClient(fileId);

            await blobClient.UploadAsync(
                request.steam,
                new BlobHttpHeaders {ContentType = request.contentType },
                cancellationToken: request.token
                );

            return fileId;
        }
    }
}
