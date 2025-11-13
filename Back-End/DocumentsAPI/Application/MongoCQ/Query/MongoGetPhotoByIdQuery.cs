using Application.DTO;
using MediatR;

namespace Application.MongoCQ.Query
{
    public record MongoGetPhotoByIdQuery(string Id) : IRequest<PhotoDTO>;
}
