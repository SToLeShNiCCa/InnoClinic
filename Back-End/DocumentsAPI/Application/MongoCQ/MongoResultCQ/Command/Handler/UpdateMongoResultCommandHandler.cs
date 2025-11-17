using Application.DTO;
using Domain.Models;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command.Handler
{
    public class UpdateMongoResultCommandHandler : IRequestHandler<UpdateMongoResultCommand, ReadResultDTO>
    {
        private readonly IResultRepository _repository;
        public UpdateMongoResultCommandHandler(IResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<ReadResultDTO> Handle(UpdateMongoResultCommand request, CancellationToken cancellationToken)
        {
            var updatedResult = request.UpdatedResultDTO.Adapt<Result>();
            await _repository.UpdateResult(request.Id, updatedResult, cancellationToken);

            var readResultDTO = updatedResult.Adapt<ReadResultDTO>();
            return readResultDTO;
        }
    }
}
