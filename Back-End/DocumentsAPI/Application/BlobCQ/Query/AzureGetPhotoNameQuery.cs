using MediatR;

namespace Application.BlobCQ.Query
{
    public record class AzureGetPhotoNameQuery(Guid fileId, CancellationToken token) : IRequest<string>;
}
