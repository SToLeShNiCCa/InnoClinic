using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IServiceCategoryRepository
    {
        Task<PaginatedResult<ServiceCategory>> GetAllAsync(PageInfo param, CancellationToken token);
        Task<ServiceCategory?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(ServiceCategory doctor, CancellationToken token);
        void Delete(ServiceCategory doctor);
        Task SaveDataAsync(CancellationToken token);
    }
}
