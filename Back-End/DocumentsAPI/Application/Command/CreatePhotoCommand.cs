using MediatR;

namespace Application.Command
{
    public record CreatePhotoCommand(string Url) : IRequest<string>;
}
