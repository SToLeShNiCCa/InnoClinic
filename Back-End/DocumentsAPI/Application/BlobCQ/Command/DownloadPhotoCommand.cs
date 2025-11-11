using Application.Storage.Response;
using MediatR;

namespace Application.BlobCQ.Command
{
    public record class DownloadPhotoCommand(Guid fileId, CancellationToken token) : IRequest<FileResponse>;
}
