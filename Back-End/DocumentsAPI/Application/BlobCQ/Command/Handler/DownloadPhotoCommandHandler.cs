using Application.Storage.Response;
using Infrastructure.BlobRepository.Interface;
using MediatR;

namespace Application.BlobCQ.Command.Handler
{
    public class DownloadPhotoCommandHandler : IRequestHandler<DownloadPhotoCommand, FileResponse>
    {
        private readonly IBlobRepository _blobRepository;
        public DownloadPhotoCommandHandler(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }
        public async Task<FileResponse> Handle(DownloadPhotoCommand request, CancellationToken cancellationToken)
        {
            var blobClient = _blobRepository.AddBlobClient(request.fileId);
            var response = await blobClient.DownloadContentAsync(cancellationToken: request.token);

            return new FileResponse(response.Value.Content.ToStream(), response.Value.Details.ContentType);
        }
    }
}
