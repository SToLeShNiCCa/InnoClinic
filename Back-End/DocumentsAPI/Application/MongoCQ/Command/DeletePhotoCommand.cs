using MediatR;

namespace Application.MongoCQ.Command
{
    public record DeletePhotoCommand(string Id) : IRequest<Unit>;
}
