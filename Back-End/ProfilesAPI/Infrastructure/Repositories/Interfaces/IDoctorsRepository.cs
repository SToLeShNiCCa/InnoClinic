using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IDoctorsRepository
    {
        Task<ActionResult<PaginatedResult<Doctor>>> GetAllAsync(PageInfo param, CancellationToken token);
        Task<Doctor?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(Doctor doctor, CancellationToken token);
        Task UpdateAsync(Doctor doctor, CancellationToken token);
        Task DeleteAsync(Doctor doctor, CancellationToken token);
        Task SaveData(CancellationToken token);
    }
}
