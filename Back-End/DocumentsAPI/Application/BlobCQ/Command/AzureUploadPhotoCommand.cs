using MediatR;

namespace Application.BlobCQ.Command
{
    public record class AzureUploadPhotoCommand(Stream Stream, string ContentType) : IRequest<Guid>;
}
