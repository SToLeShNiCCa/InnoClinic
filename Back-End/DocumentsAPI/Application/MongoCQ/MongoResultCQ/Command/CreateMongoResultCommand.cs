using Application.DTO;
using Domain.Models;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command
{
    public record class CreateMongoResultCommand(CreateResultDTO ResultDTO):IRequest<ReadResultDTO>;
}
