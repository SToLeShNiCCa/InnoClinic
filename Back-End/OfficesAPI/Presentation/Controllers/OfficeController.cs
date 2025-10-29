using Application.DTO;
using Application.Services.Interface;
using Domain.Models.PageModels;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        public OfficeController(IOfficeService service)
        {
            _officeService = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] PageInfo pageInfo)
        {
            var result = await _officeService.GetAllAsync(pageInfo);
            return result.ToActionResult();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _officeService.GetByIdAsync(id);
            return result.ToActionResult();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateOfficeDTO dto)
        {
            var result = await _officeService.CreateAsync(dto);
            return result.ToActionResult();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(string id, UpdateOfficeDTO dto)
        {
            var result = await _officeService.Update(id, dto);
            return result.ToActionResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(string id)
        {
            var result = await _officeService.RemoveAsync(id);
            return result.ToActionResult();
        }
    }
}
