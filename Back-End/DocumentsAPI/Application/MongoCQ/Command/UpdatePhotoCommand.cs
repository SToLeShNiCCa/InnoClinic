using MediatR;

namespace Application.MongoCQ.Command
{
    public record UpdatePhotoCommand(string Id, string Url) : IRequest<Unit>;
}
