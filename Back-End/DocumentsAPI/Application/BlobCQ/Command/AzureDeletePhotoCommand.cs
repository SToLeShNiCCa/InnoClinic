using MediatR;

namespace Application.BlobCQ.Command
{
    public record class AzureDeletePhotoCommand(Guid fileId, CancellationToken token): IRequest<Unit>;
}
