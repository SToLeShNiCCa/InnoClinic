using MediatR;

namespace Application.BlobCQ.Command
{
    public record class DeletePhotoCommand(Guid fileId, CancellationToken token): IRequest<Unit>;
}
