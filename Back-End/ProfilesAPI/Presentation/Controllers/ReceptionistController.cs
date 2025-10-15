using Application.DTO.Receptionist;
using AutoMapper;
using Domain.DBServices.Models;
using Infrastructure.DbConfigurations.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    /// <summary>
    /// ReceptionistController class - API controller for managing receptionist entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistController : ControllerBase
    {
        /// <summary>
        /// Controller's dependencies.
        /// </summary>
        private readonly ProfilesContext _dbContext;
        private readonly IMapper _mapper;
        public ReceptionistController(ProfilesContext context, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        /// <summary>
        /// Gets all receptionists from the database.
        /// </summary>
        /// <returns>receptionist's list.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receptionist>>> GetAll()
        {
            return await _dbContext.Receptionists.ToListAsync();
        }

        /// <summary>
        /// Gets a receptionist by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>Receptionist object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Receptionist>> GetById(int id)
        {
            var receptionist = await _dbContext.Receptionists.FindAsync(id);

            if (receptionist == null) return NotFound();

            return receptionist;
        }

        /// <summary>
        /// Posts a new receptionist to the database.
        /// </summary>
        /// <param name="dto">Receptionist's DTO.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Receptionist>> Create(CreateReceptionistDTO dto)
        {
            var receptionist = _mapper.Map<Receptionist>(dto);

            _dbContext.Receptionists.Add(receptionist);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = receptionist.Id }, receptionist);
        }

        /// <summary>
        /// Updates an existing receptionist in the database.
        /// </summary>
        /// <param name="dto">Receptionist's DTO.</param>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(CreateReceptionistDTO dto, int id)
        {
            var receptionist = await _dbContext.Receptionists.FindAsync(id);
            if (receptionist == null) return NotFound();

            _mapper.Map(dto, receptionist);
            await _dbContext.SaveChangesAsync();

            return Ok(_mapper.Map<CreateReceptionistDTO>(receptionist));
        }

        /// <summary>
        /// Deletes a receptionist from the database.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var receptionist = await _dbContext.Receptionists.FindAsync(id);
            if (receptionist == null) return NotFound();

            _dbContext.Receptionists.Remove(receptionist);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
