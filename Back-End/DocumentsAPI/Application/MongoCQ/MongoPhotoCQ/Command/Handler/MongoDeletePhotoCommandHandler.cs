using Application.MongoCQ.MongoPhotoCQ.Command;
using Infrastructure.MongoRepository.Photos.Interfaces;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Command.Handler
{
    public class MongoDeletePhotoCommandHandler : IRequestHandler<MongoDeletePhotoCommand, Unit>
    {

        private readonly IPhotoRepository _photoRepository;

        public MongoDeletePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<Unit> Handle(MongoDeletePhotoCommand request, CancellationToken token)
        {
            await _photoRepository.DeleteAsync(request.Id, token);

            return Unit.Value;
        }
    }
}
