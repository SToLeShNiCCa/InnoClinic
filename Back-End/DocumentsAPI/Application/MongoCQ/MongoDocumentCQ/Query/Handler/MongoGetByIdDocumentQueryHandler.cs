using Application.DTO;
using Infrastructure.MongoRepository.Documents.Interface;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Query.Handler
{
    public class MongoGetByIdDocumentQueryHandler : IRequestHandler<MongoGetByIdDocumentQuery, DocumentDTO>
    {
        private readonly IDocumentRepository _repository;

        public MongoGetByIdDocumentQueryHandler(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<DocumentDTO> Handle(MongoGetByIdDocumentQuery request, CancellationToken token)
        {
            var result = await _repository.GetByIdAsync(request.Id, token);

            return result.Adapt<DocumentDTO>();
        }
    }
}
