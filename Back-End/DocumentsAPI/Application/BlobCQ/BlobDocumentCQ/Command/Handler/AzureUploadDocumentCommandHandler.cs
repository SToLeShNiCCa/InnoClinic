using Azure.Storage.Blobs.Models;
using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.BlobDocumentCQ.Command.Handler
{
    public class AzureUploadDocumentCommandHandler : IRequestHandler<AzureUploadDocumentCommand, string>
    {

        private readonly IBlobRepository _blobRepository;

        public AzureUploadDocumentCommandHandler(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }

        public async Task<string> Handle(AzureUploadDocumentCommand request, CancellationToken token)
        {
            var fileId = Guid.NewGuid();
            var blobClient = _blobRepository.AddDocumentBlobClient(fileId);

            using var memoryStream = new MemoryStream(request.Bytes);

            await blobClient.UploadAsync(
                memoryStream,
                new BlobHttpHeaders { ContentType = request.ContentType },
                cancellationToken: token
                );

            return blobClient.Uri.ToString();
        }
    }
}
