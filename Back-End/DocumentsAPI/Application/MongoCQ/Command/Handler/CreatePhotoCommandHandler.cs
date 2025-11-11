using Application.MongoCQ.Command;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.MongoCQ.Command.Handler
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, string>
    {
        private readonly IPhotoRepository _photoRepository;

        public CreatePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<string> Handle(CreatePhotoCommand request, CancellationToken token)
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
