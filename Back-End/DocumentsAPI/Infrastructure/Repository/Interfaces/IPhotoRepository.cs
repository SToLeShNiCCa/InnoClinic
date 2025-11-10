using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo?> GetByUrlAsync(string url, CancellationToken token);
        Task<PaginatedResult<Photo>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task AddAsync(Photo photo, CancellationToken token);
        Task DeleteAsync (string url, CancellationToken token);
        Task UpdateAsync(string url, Photo newPhoto, CancellationToken token);
    }
}
