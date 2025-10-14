using Application.DTO.Doctors;
using Application.Services.Interfaces;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Presentation.Controllers
{
    /// <summary>
    /// DoctorController class - API controller for managing doctor entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        /// <summary>
        /// Controller's dependencies.
        /// </summary>
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all doctors from the database.
        /// </summary>
        /// <returns>Doctor's list</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDoctorDTO>>> GetAll(PageInfo param,CancellationToken token)
        {
            var doctors = await _service.GetAllAsync(param,token);
            return Ok(doctors);
        }

        /// <summary>
        /// Gets a doctor by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Doctor's object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDoctorDTO>> GetByIdAsync(int id , CancellationToken token)
        {
            return await _service.GetByIdAsync(id, token);
        }

        /// <summary>
        /// Posts a new doctor to the database.
        /// </summary>
        /// <param name="dto">Doctor's DTO</param>
        /// <returns>Proof that doctor was created(REST)</returns>
        [HttpPost]
        public async Task<ActionResult<Doctor>> Create(CreateDoctorDTO dto, CancellationToken token)
        {
            var createdDoctor = await _service.CreateAsync(dto, token);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdDoctor.Id }, createdDoctor);
        }

        /// <summary>
        /// Updates an existing doctor's information.
        /// </summary>
        /// <param name="dto">Doctor's DTO</param>
        /// <param name="id">Unique identifier</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateDoctorDTO dto,CancellationToken token)
        {
            await _service.UpdateAsync(dto,token);
            return NoContent();
        }

        /// <summary>
        /// Deletes a doctor by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id,CancellationToken token)
        {
            await _service.DeleteAsync(id,token);
            return NoContent();
        }
    }
}
