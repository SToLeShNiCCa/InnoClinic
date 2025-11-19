using MediatR;

namespace Application.BlobCQ.BlobDocumentCQ.Command
{
    public record class AzureDeleteDocumentCommand(Guid documentId ):IRequest<Unit>;
}
