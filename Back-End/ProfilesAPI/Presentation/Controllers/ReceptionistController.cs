using Application.DTO.Receptionist;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    /// <summary>
    /// ReceptionistController class - API controller for managing receptionist entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionistService _service;
        public ReceptionistController(IReceptionistService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all receptionists from the database.
        /// </summary>
        /// <returns>receptionist's list.</returns>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Receptionist>>> GetAll([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var receptionists = await _service.GetAllAsync(pageInfo, token);

            return receptionists.ToActionResult();
        }

        /// <summary>
        /// Gets a receptionist by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>Receptionist object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Receptionist>> GetById(int id, CancellationToken token)
        {
            var receptionist = await _service.GetByIdAsync(id, token);

            return receptionist.ToActionResult();
        }

        /// <summary>
        /// Posts a new receptionist to the database.
        /// </summary>
        /// <param name="dto">Receptionist's DTO.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Receptionist>> Create(CreateReceptionistDTO dto, CancellationToken token)
        {
            var createdReceptionist = await _service.CreateAsync(dto, token);

            return createdReceptionist.ToActionResult();
        }

        /// <summary>
        /// Updates an existing receptionist in the database.
        /// </summary>
        /// <param name="dto">Receptionist's DTO.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateReceptionistDTO dto, CancellationToken token)
        {
            var updatedReceptionist = await _service.UpdateAsync(dto, token);

            return updatedReceptionist.ToActionResult();
        }

        /// <summary>
        /// Deletes a receptionist from the database.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id,CancellationToken token)
        {
            await _service.DeleteAsync(id, token);

            return NoContent();
        }
    }
}
