using Application.DTO;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.Query.Handler
{
    public class GetPhotoByIdHandler : IRequestHandler<GetPhotoByIdQuery, PhotoDTO>
    {
        private readonly IPhotoRepository _repository;
        public GetPhotoByIdHandler(IPhotoRepository repository)
        {
            _repository = repository;
        }
        public async Task<PhotoDTO> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            var photo = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (photo == null) throw new Exception("photo is not found");

            var photoDTO = new PhotoDTO(photo.Id, photo.Url);

            return photoDTO;
        }
    }
}
