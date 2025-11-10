using Domain.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo?> GetByUrlAsync(string url, CancellationToken token);
        Task<IReadOnlyCollection<Photo>> GetAll(CancellationToken token);//PaginatedResult
        Task AddAsync(Photo photo, CancellationToken token);
        void Delete (string url);
        Task UpdateAsync(string url, Photo newPhoto, CancellationToken token);
    }
}
