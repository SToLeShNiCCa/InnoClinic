using MediatR;

namespace Application.Command
{
    public record UpdatePhotoCommand(string Id, string Url) : IRequest<Unit>;
}
