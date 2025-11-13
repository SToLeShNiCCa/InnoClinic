using Infrastructure.BlobRepository.Interface;
using MediatR;

namespace Application.BlobCQ.Query.Handler
{
    public class AzureGetPhotoNameQueryHandler : IRequestHandler<AzureGetPhotoNameQuery, string>
    {
        private readonly IBlobRepository _blobRepository;
        public AzureGetPhotoNameQueryHandler(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }
        public Task<string> Handle(AzureGetPhotoNameQuery request, CancellationToken token)
        {
            var blobClient = _blobRepository.AddBlobClient(request.fileId);

            return Task.FromResult(blobClient.Name);
        }
    }
}
