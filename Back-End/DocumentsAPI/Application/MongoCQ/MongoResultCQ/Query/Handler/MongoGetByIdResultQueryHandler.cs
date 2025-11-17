using Application.DTO.ResultDTO;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Query.Handler
{
    public class MongoGetByIdResultQueryHandler : IRequestHandler<MongoGetByIdResultQuery, ReadResultDTO>
    {

        private readonly IResultRepository _repository;

        public MongoGetByIdResultQueryHandler(IResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReadResultDTO> Handle(MongoGetByIdResultQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
            //хз надо бы проверки добавить
            return result.Adapt<ReadResultDTO>();
        }
    }
}
