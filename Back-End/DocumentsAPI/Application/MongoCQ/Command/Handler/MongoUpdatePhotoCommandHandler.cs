using Domain.Models;
using Infrastructure.MongoRepository.Interfaces;
using MediatR;

namespace Application.MongoCQ.Command.Handler
{
    public class MongoUpdatePhotoCommandHandler : IRequestHandler<MongoUpdatePhotoCommand, Unit>
    {
        private readonly IPhotoRepository _photoRepository;

        public MongoUpdatePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<Unit> Handle(MongoUpdatePhotoCommand request, CancellationToken token)
        {
            var photo = new Photo()
            {
                Url = request.Url,
            };
            await _photoRepository.UpdateAsync(request.Id, photo, token);
            return Unit.Value;
        }
    }
}
