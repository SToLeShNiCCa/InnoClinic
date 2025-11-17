using Application.DTO;
using Infrastructure.MongoRepository.Photos.Interfaces;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Query.Handler
{
    public class MongoGetPhotoByIdHandler : IRequestHandler<MongoGetByIdPhotoQuery, PhotoDTO>
    {

        private readonly IPhotoRepository _repository;

        public MongoGetPhotoByIdHandler(IPhotoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PhotoDTO> Handle(MongoGetByIdPhotoQuery request, CancellationToken cancellationToken)
        {
            var photo = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (photo == null) throw new Exception("photo is not found");//Result

            var photoDTO = new PhotoDTO(photo.Url);

            return photoDTO;
        }
    }
}
