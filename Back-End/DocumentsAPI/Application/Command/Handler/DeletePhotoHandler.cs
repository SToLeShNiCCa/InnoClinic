using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.Command.Handler
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, Unit>
    {
        private readonly IPhotoRepository _photoRepository;

        public DeletePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken token)
        {
            var photo = await _photoRepository.GetByIdAsync(request.Id, token);

            await _photoRepository.DeleteAsync(request.Id, token);
            return Unit.Value;
        }
    }
}
