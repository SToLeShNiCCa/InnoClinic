using MediatR;

namespace Application.MongoCQ.Command
{
    public record CreatePhotoCommand(string Url) : IRequest<string>;
}
