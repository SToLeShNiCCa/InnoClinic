using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.Command.Handler
{
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, Unit>
    {
        private readonly IPhotoRepository _photoRepository;

        public UpdatePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<Unit> Handle(UpdatePhotoCommand request, CancellationToken token)
        {
            var photo = await _photoRepository.GetByIdAsync(request.Id, token);

            var newPhoto = new Photo()
            {
                Id = photo.Id,
                Url = request.Url
            };
            await _photoRepository.UpdateAsync(request.Id, newPhoto, token);
            return Unit.Value;
        }
    }
}
