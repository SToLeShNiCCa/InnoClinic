using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Query
{
    public record class AzureGetPhotoNameQuery(Guid fileId) : IRequest<string>;
}
