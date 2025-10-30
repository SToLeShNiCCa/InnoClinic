using Application.DTO;
using Application.DTO.Result;
using Domain.Models.PageModels;

namespace Application.Services.Interface
{
    public interface IOfficeService
    {
        Task<Result<IReadOnlyCollection<ReadOfficeDTO>>> GetAllAsync(PageInfo pageInfo);
        Task<Result<ReadOfficeDTO>> GetByIdAsync(string id);
        Task<Result<ReadOfficeDTO>> CreateAsync(CreateOfficeDTO newOffice);
        Task<Result<ReadOfficeDTO>> Update(string id, UpdateOfficeDTO updatedOffice);
        Task<Result> RemoveAsync(string id);
    }
}