using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interface
{
    public interface IOfficeRepository
    {
        Task<PaginatedResult<Office>> GetAllAsync(PageInfo pageInfo);
        Task<Office?> GetByIdAsync(string id);
        Task CreateAsync(Office newOffice);
        Task Update(string id, Office updatedOffice);
        Task RemoveAsync(string id);
    }
}
