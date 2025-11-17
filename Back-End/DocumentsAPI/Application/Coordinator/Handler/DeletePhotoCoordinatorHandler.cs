using Application.BlobCQ.BlobPhotoCQ.Command;
using Application.MongoCQ.MongoPhotoCQ.Command;
using Application.MongoCQ.MongoPhotoCQ.Query;
using MediatR;

namespace Application.Coordinator.Handler
{
    public class DeletePhotoCoordinatorHandler : IRequestHandler<DeletePhotoCoordinatorCommand, Unit>
    {
        private readonly IMediator _mediator;

        public DeletePhotoCoordinatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeletePhotoCoordinatorCommand request, CancellationToken token)
        {
            var photoId = await GetPhotoUrlFromMongo(request.Id, token);

            await DeletePhotoFromMongo(request.Id, token);
            await DeletePhotoFromAzure(Guid.Parse(photoId), token);

            return Unit.Value;
        }

        private async Task<string> GetPhotoUrlFromMongo(string id, CancellationToken token)
        {
            var query = new MongoGetPhotoByIdQuery(id);
            var photo = await _mediator.Send(query, token);

            return photo.Url;
        }

        private async Task DeletePhotoFromMongo(string id, CancellationToken token)
        {
            var command = new MongoDeletePhotoCommand(id);
            await _mediator.Send(command, token);
        }

        private async Task DeletePhotoFromAzure(Guid fileId, CancellationToken token)
        {
            var deleteCommand = new AzureDeletePhotoCommand(fileId);
            await _mediator.Send(deleteCommand, token);
        }
    }
}
