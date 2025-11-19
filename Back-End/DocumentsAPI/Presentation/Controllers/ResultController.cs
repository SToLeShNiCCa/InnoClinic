using Application.DTO.ResultDTO;
using Application.MongoCQ.MongoResultCQ.Command;
using Application.MongoCQ.MongoResultCQ.Query;
using Application.PDFGenerationCQ;
using Infrastructure.PageSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllResults([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var query = new MongoGetAllResultsQuery(pageInfo);
            var results = await _mediator.Send(query, token);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetResultById(string id, CancellationToken token)
        {
            var query = new MongoGetByIdResultQuery(id);
            var result = await _mediator.Send(query, token);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateResult([FromBody] CreateResultDTO resultDTO, CancellationToken token)
        {
            var createCommand = new CreateMongoResultCommand(resultDTO);
            var createdResult = await _mediator.Send(createCommand, token);

            var command = new PDFGenerationCommand(resultDTO);
            var pdfFileId = await _mediator.Send(command, token);

            return Ok(pdfFileId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResult(string id, CancellationToken token)
        {
            var command = new DeleteMongoResultCommand(id);
            var result = await _mediator.Send(command, token);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateResult(string id, [FromBody] UpdateResultDTO updatedResultDTO, CancellationToken token)
        {
            var command = new UpdateMongoResultCommand(id, updatedResultDTO);
            var result = await _mediator.Send(command, token);

            return Ok(result);
        }
    }
}
