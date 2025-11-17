using Infrastructure.MongoRepository.Photos.Interfaces;
using MediatR;

namespace Application.MongoCQ.Command.Handler
{
    public class MongoDeletePhotoCommandHandler(IPhotoRepository _photoRepository)
        : IRequestHandler<MongoDeletePhotoCommand, Unit>
    {
        public async Task<Unit> Handle(MongoDeletePhotoCommand request, CancellationToken token)
        {
            await _photoRepository.DeleteAsync(request.Id, token);

            return Unit.Value;
        }
    }
}
