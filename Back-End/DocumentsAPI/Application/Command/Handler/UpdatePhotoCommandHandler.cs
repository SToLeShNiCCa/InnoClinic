using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Handler
{
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, string>
    {
        private readonly IPhotoRepository _photoRepository;

        public UpdatePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<string> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new Photo(request.Url);
            await _photoRepository.CreateAsync(photo);
            return photo.Id;
        }
    }
}
