using Infrastructure.MongoRepository.Documents.Interface;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Command.Handler
{
    public class MongoDeleteDocumentCommandHandler : IRequestHandler<MongoDeleteDocumentCommand, Unit>
    {
        private readonly IDocumentRepository _repository;

        public MongoDeleteDocumentCommandHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(MongoDeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.DocumentId, cancellationToken);
            return Unit.Value;
        }
    }
}
