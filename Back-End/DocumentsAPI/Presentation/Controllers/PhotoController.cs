using Application.Coordinator;
using Application.DTO;
using Application.DTO.Requests;
using Application.DTO.Response;
using Application.MongoCQ.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController(IMediator _mediator) : ControllerBase
    {
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
            var coordinator = new CreatePhotoCoordinatorCommand(request);
            var response = await _mediator.Send(coordinator, token);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(string id,CancellationToken token)
        {
            var coordinator = new DeletePhotoCoordinatorCommand(id);
            await _mediator.Send(coordinator, token);

            return NoContent();
        }
    }
}
