using Application.MongoCQ.Command;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.MongoCQ.Command.Handler
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
            var photo = new Photo()
            {
                Url = request.Url
            };
            await _photoRepository.CreateAsync(photo, token);

            return photo.Id;
        }
    }
}
