using Application.DTO;
using Application.MongoCQ.Command;
using Application.MongoCQ.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDTO>> GetPhoto(string id)
        {
            var query = new GetPhotoByIdQuery(id);
            var photo = await _mediator.Send(query);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePhoto(CreatePhotoRequest request)
        {
            var command = new CreatePhotoCommand(request.Url);
            var photoId = await _mediator.Send(command);

            return Ok(photoId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhoto(UpdatePhotoRequest request, string id)
        {
            var command = new UpdatePhotoCommand(id, request.Url);
            var newPhoto = await _mediator.Send(command);

            return Ok(newPhoto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(string id)
        {
            var command = new DeletePhotoCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
