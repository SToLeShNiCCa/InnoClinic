using Application.DTO;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Query
{
    public record class MongoGetByIdResultQuery(string Id) : IRequest<ReadResultDTO>;
}
