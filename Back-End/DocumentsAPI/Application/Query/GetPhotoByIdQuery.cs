using Application.DTO;
using MediatR;

namespace Application.Query
{
    public record GetPhotoByIdQuery(string Id) : IRequest<PhotoDTO>;
}
