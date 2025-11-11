using Application.MongoCQ.Command;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.MongoCQ.Command.Handler
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
            var photo = new Photo()
            {
                Url = request.Url,
            };
            await _photoRepository.UpdateAsync(request.Id, photo, token);
            return Unit.Value;
        }
    }
}
