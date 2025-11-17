using Infrastructure.MongoRepository.Results.Interfaces;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command.Handler
{
    public class DeleteMongoResultCommandHandler : IRequestHandler<DeleteMongoResultCommand, Unit>
    {

        private readonly IResultRepository _repository;

        public DeleteMongoResultCommandHandler(IResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMongoResultCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
