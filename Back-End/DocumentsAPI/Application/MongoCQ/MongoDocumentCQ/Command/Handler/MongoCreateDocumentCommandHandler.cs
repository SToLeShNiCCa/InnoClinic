using Domain.Models;
using Infrastructure.MongoRepository.Documents.Interface;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Command.Handler
{
    public class MongoCreateDocumentCommandHandler : IRequestHandler<MongoCreateDocumentCommand, string>
    {
        private readonly IDocumentRepository _repository;

        public MongoCreateDocumentCommandHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(MongoCreateDocumentCommand request, CancellationToken token)
        {
            var document = new Document
            {
                ResultId = request.ResultId,
                Url = request.Url
            };
            await _repository.CreateAsync(document, token);

            return document.Id;
        }
    }
}
