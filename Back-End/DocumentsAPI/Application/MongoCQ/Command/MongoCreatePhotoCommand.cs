using MediatR;

namespace Application.MongoCQ.Command
{
    public record MongoCreatePhotoCommand(string Url) : IRequest<string>;
}
