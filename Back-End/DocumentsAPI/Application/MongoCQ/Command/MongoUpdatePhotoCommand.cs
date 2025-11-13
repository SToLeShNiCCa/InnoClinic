using MediatR;

namespace Application.MongoCQ.Command
{
    public record MongoUpdatePhotoCommand(string Id, string Url) : IRequest<Unit>;
}
