using Application.DTO;
using Infrastructure.MongoRepository.Interfaces;
using MediatR;

namespace Application.MongoCQ.Query.Handler
{
    public class MongoGetPhotoByIdHandler(IPhotoRepository _repository)
        : IRequestHandler<MongoGetPhotoByIdQuery, PhotoDTO>
    {
        public async Task<PhotoDTO> Handle(MongoGetPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            var photo = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (photo == null) throw new Exception("photo is not found");//Result

            var photoDTO = new PhotoDTO(photo.Url);

            return photoDTO;
        }
    }
}
