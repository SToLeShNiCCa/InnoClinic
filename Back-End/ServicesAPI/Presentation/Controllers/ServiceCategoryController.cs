using Application.DTO.ServiceCategoryDTO;
using Application.Services.Interfaces;
using Domain.Models.PageModels;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extension;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryServices _service;

        public ServiceCategoryController(IServiceCategoryServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceCategories([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _service.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetServiceCategoryById(int id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCategory(
            CreateServiceCategoryDTO serviceCategoryDTO, CancellationToken token)
        {
            var result = await _service.CreateAsync(serviceCategoryDTO, token);

            return result.ToActionResult();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateServiceCategory(
            int id, UpdateServiceCategoryDTO serviceCategoryDTO, CancellationToken token)
        {
            var result = await _service.UpdateAsync(id, serviceCategoryDTO, token);

            return result.ToActionResult();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteServiceCategory(int id, CancellationToken token)
        {
            var result = await _service.DeleteAsync(id, token);

            return result.ToActionResult();
        }
    }
}
