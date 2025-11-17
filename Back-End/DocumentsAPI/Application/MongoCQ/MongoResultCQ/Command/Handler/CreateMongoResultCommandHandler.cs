using Application.DTO.ResultDTO;
using Domain.Models;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command.Handler
{
    public class CreateMongoResultCommandHandler : IRequestHandler<CreateMongoResultCommand, ReadResultDTO>
    {
        private readonly IResultRepository _repository;
        public CreateMongoResultCommandHandler(IResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<ReadResultDTO> Handle(CreateMongoResultCommand request, CancellationToken cancellationToken)
        {
            var result = request.ResultDTO.Adapt<Result>();
            await _repository.CreateAsync(result, cancellationToken);

            return result.Adapt<ReadResultDTO>();
        }
    }
}
