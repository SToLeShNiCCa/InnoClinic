using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo?> GetByIdAsync(string id, CancellationToken token);
        Task<PaginatedResult<Photo>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task CreateAsync(Photo photo, CancellationToken token);
        Task DeleteAsync (string id, CancellationToken token);
        Task UpdateAsync(string id, Photo newPhoto, CancellationToken token);
    }
}
