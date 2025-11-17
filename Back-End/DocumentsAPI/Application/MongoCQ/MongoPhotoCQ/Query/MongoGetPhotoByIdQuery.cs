using Application.DTO;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Query
{
    public record MongoGetPhotoByIdQuery(string Id) : IRequest<PhotoDTO>;
}
