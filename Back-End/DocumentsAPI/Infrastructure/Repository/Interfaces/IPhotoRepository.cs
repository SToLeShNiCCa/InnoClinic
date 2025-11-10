using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo?> GetByUrlAsync(string url, CancellationToken token);
        Task<PaginatedResult<Photo>> GetAll(CancellationToken token);
        Task AddAsync(Photo photo, CancellationToken token);
        void Delete (string url);
        Task UpdateAsync(string url, Photo newPhoto, CancellationToken token);
    }
}
