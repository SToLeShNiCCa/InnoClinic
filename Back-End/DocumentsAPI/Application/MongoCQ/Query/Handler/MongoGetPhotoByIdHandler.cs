using Application.DTO;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.MongoCQ.Query.Handler
{
    public class MongoGetPhotoByIdHandler : IRequestHandler<MongoGetPhotoByIdQuery, PhotoDTO>
    {
        private readonly IPhotoRepository _repository;
        public MongoGetPhotoByIdHandler(IPhotoRepository repository)
        {
            _repository = repository;
        }
        public async Task<PhotoDTO> Handle(MongoGetPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            var photo = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (photo == null) throw new Exception("photo is not found");

            var photoDTO = new PhotoDTO(photo.Url);

            return photoDTO;
        }
    }
}
