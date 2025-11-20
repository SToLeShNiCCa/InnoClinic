using Application.DTO.Response;
using Application.MongoCQ.MongoDocumentCQ.Command;
using Application.MongoCQ.MongoResultCQ.Command;
using Application.PDFGenerationCQ;
using MediatR;

namespace Application.Coordinator.Document.Handler
{
    public class CreateDocumentCoordinatorCommandHandler : IRequestHandler<CreateDocumentCoordinatorCommand, string>
    {

        private readonly IMediator _mediator;

        public CreateDocumentCoordinatorCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateDocumentCoordinatorCommand request, CancellationToken token)
        {
            var resultId =  await AddResultToMongo(request, token);
            var url = await GeneratePDFMethod(request, token);
            await CreateDocumentInMongo(url, resultId, token);

            return url;
        }

        private async Task<string> AddResultToMongo(CreateDocumentCoordinatorCommand request, CancellationToken token)
        {
            var command = new CreateMongoResultCommand(request.ResultDTO);
            var resultId = await _mediator.Send(command, token);

            return resultId;
        }

        private async Task<string> GeneratePDFMethod(CreateDocumentCoordinatorCommand request, CancellationToken token)
        {
            var command = new PDFGenerationCommand(request.ResultDTO);
            var url = await _mediator.Send(command, token);

            return url;
        }

        private async Task CreateDocumentInMongo(string url, string resultId, CancellationToken token)
        {
            var command = new MongoCreateDocumentCommand(url, resultId);
            await _mediator.Send(command, token);

            return;
        }
    }
}
