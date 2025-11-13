using MediatR;

namespace Application.MongoCQ.Command
{
    public record MongoDeletePhotoCommand(string Id) : IRequest<Unit>;
}
