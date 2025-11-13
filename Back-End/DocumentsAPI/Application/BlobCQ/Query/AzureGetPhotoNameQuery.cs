using MediatR;

namespace Application.BlobCQ.Query
{
    public record class AzureGetPhotoNameQuery(Guid fileId) : IRequest<string>;
}
