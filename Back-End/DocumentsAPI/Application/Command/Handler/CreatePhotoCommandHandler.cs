using AutoMapper;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace Application.Command.Handler
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, string>
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public CreatePhotoCommandHandler(IPhotoRepository photoRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
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
