using Application.DTO;
using Infrastructure.PageSettings;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Query
{
    public record class MongoGetAllResultsQuery(PageInfo PageInfo):IRequest<IReadOnlyCollection<ReadResultDTO>>;
}
