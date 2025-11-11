using Application.DTO;
using MediatR;

namespace Application.MongoCQ.Query
{
    public record GetPhotoByIdQuery(string Id) : IRequest<PhotoDTO>;
}
