using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IServiceRepository
    {
        Task<PaginatedResult<Service>> GetAllAsync(PageInfo param, CancellationToken token);
        Task<Service?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(Service doctor, CancellationToken token);
        void Delete(Service doctor);
        Task SaveDataAsync(CancellationToken token);
    }
}
