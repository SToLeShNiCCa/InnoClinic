using Application.DTO.ServiceDTO;
using Application.Services.Interfaces;
using Domain.Models.PageModels;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extension;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceServices _service;

        public ServiceController(IServiceServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _service.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetServiceById(int id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteService(int id, CancellationToken token)
        {
            var result = await _service.DeleteAsync(id, token);

            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDTO serviceDTO, CancellationToken token)
        {
            var result = await _service.CreateAsync(serviceDTO, token);

            return result.ToActionResult();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateService(int id, UpdateServiceDTO serviceDTO, CancellationToken token)
        {
            var result = await _service.UpdateAsync(id, serviceDTO, token);

            return result.ToActionResult();
        }

    }
}
