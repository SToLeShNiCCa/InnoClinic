using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.Command.Handler
{
    public class AzureDeletePhotoCommandHandler : IRequestHandler<AzureDeletePhotoCommand, Unit>
    {
        private readonly IBlobRepository _blobRepository;
        public AzureDeletePhotoCommandHandler(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }
        public async Task<Unit> Handle(AzureDeletePhotoCommand request, CancellationToken token)
        {
            var blobClient = _blobRepository.AddBlobClient(request.fileId);

            await blobClient.DeleteIfExistsAsync(cancellationToken: token);

            return Unit.Value;
        }
    }
}
