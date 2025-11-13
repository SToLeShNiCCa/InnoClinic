using MediatR;

namespace Application.BlobCQ.Command
{
    public record class AzureDeletePhotoCommand(Guid fileId): IRequest<Unit>;
}
