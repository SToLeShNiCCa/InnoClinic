using MediatR;

namespace Application.BlobCQ.Command
{
    public record class UploadPhotoCommand(Stream steam, string contentType, CancellationToken token) : IRequest<Guid>;
}
