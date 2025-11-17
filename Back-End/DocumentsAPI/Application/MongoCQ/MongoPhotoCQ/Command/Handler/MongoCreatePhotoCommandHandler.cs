using Application.Exceptions.MongoExceptions;
using Domain.Models;
using Infrastructure.MongoRepository.Photos.Interfaces;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Command.Handler
{
    public class MongoCreatePhotoCommandHandler : IRequestHandler<MongoCreatePhotoCommand, string>
    {

        private readonly IPhotoRepository _photoRepository;

        public MongoCreatePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<string> Handle(MongoCreatePhotoCommand request, CancellationToken token)
        {
            try
            {
                var photo = new Photo()
                {
                    Url = request.Url
                };
                await _photoRepository.CreateAsync(photo, token);

                return photo.Id;
            }
            catch (AddMongoDataException)
            {
                throw new AddMongoDataException("Failed to add photo data to MongoDB.");
            }
        }
    }
}
