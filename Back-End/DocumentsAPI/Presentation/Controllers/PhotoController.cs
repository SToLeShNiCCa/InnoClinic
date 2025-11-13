using Application.BlobCQ.Command;
using Application.BlobCQ.Query;
using Application.DTO;
using Application.MongoCQ.Command;
using Application.MongoCQ.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Requests;
using Presentation.Response;

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
        public async Task<ActionResult<PhotoDTO>> GetPhoto(string id, CancellationToken token)
        {
            var query = new MongoGetPhotoByIdQuery(id);
            var photo = await _mediator.Send(query, token);

            return Ok(photo);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<PhotoResponse>> UploadPhoto([FromForm] UploadPhotoRequest request, CancellationToken token)
        {
            await using var stream = request.File.OpenReadStream();
            var command = new AzureUploadPhotoCommand(stream, request.File.ContentType);

            var azureFileId = await _mediator.Send(command, token);

            var urlQuery = new AzureGetPhotoNameQuery(azureFileId);
            var url = await _mediator.Send(urlQuery, token);

            var createPhotoCommand = new MongoCreatePhotoCommand(url);
            var mongoPhotoId = await _mediator.Send(createPhotoCommand);

            var response = new PhotoResponse(azureFileId, mongoPhotoId);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhoto(UpdatePhotoRequest request, string id)
        {
            var command = new MongoUpdatePhotoCommand(id, request.Url);
            var newPhoto = await _mediator.Send(command);

            return Ok(newPhoto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(string id,CancellationToken token)
        {
            var query = new MongoGetPhotoByIdQuery(id);
            var photoId = await _mediator.Send(query, token);

            var command = new MongoDeletePhotoCommand(id);
            await _mediator.Send(command, token);

            var deleteCommand = new AzureDeletePhotoCommand(Guid.Parse(photoId.Url));
            await _mediator.Send(deleteCommand, token);

            return NoContent();
        }
    }
}
