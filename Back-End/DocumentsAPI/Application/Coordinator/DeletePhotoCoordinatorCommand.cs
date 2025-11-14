using MediatR;

namespace Application.Coordinator
{
    public record class DeletePhotoCoordinatorCommand(string Id) : IRequest<Unit>;
}
