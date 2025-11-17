using Application.DTO.ResultDTO;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Query.Handler
{
    public class MongoGetAllResultsQueryHandler
        : IRequestHandler<MongoGetAllResultsQuery, IReadOnlyCollection<ReadResultDTO>>
    {
        private readonly IResultRepository _repository;
        public MongoGetAllResultsQueryHandler(IResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyCollection<ReadResultDTO>> Handle(MongoGetAllResultsQuery request, CancellationToken cancellationToken)
        {
            var collection =  await _repository.GetAllResult(request.PageInfo, cancellationToken);
            var result = collection.Data.Adapt<IReadOnlyCollection<ReadResultDTO>>();//мб без даты

            return result;
        }
    }
}
