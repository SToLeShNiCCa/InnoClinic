using MediatR;

namespace Application.Command
{
    public record DeletePhotoCommand(string Id) : IRequest<Unit>;
}
