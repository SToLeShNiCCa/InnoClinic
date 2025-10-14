using Application.DTO.Doctors;
using Domain.DBServices.Models.PaginationModel;

namespace Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<ReadDoctorDTO>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<ReadDoctorDTO> GetByIdAsync(int id, CancellationToken token);
        Task<ReadDoctorDTO> CreateAsync(CreateDoctorDTO doctor, CancellationToken token);
        Task UpdateAsync(UpdateDoctorDTO doctor,CancellationToken token);
        Task DeleteAsync(int id,CancellationToken token);
    }
}
