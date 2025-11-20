using Application.BlobCQ.BlobDocumentCQ.Command;
using Application.DTO;
using Application.MongoCQ.MongoDocumentCQ.Query;
using Application.MongoCQ.MongoResultCQ.Command;
using Azure.Core;
using MediatR;
using Newtonsoft.Json.Linq;

namespace Application.Coordinator.Document.Handler
{
    public class DeleteDocumentCoordinatorHandler : IRequestHandler<DeleteDocumentCoordinatorCommand, Unit>
    {
        private readonly IMediator _mediator;
        public DeleteDocumentCoordinatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Unit> Handle(DeleteDocumentCoordinatorCommand request, CancellationToken token)
        {
            var documentDTO = await GetByIdDocument(request.Id, token);
            var documentId = GetGuidFromUrl(documentDTO.Url);

            await DeleteDataFromMongo(request.Id, token);
            await DeleteDataFromBlobDocument(documentId, token);

            return Unit.Value;
        }

        private async Task<DocumentDTO> GetByIdDocument(string id, CancellationToken token)
        {
            var query = new MongoGetByIdDocumentQuery(id);
            var documentDTO = await _mediator.Send(query, token);

            return documentDTO;
        }

        private async Task DeleteDataFromMongo(string id, CancellationToken token)
        {
            var command = new DeleteMongoResultCommand(id);
            await _mediator.Send(command, token);
        }

        private async Task DeleteDataFromBlobDocument(Guid id, CancellationToken token)
        {
            var deletePhotoCommand = new AzureDeleteDocumentCommand(id);
            await _mediator.Send(deletePhotoCommand, token);
        }

        private Guid GetGuidFromUrl(string url)
        {
            string result = url.Split('/').Last();

            return Guid.Parse(result);
        }
    }
}
