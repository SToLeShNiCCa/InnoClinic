using Application.DTO.Patients;
using AutoMapper;
using Domain.DBServices.Models;
using Infrastructure.DbConfigurations.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    /// <summary>
    /// PatientController class - API controller for managing patient entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        /// <summary>
        /// Controller's dependencies.
        /// </summary>
        private readonly ProfilesContext _dbContext;
        private readonly IMapper _mapper;

        public PatientController(ProfilesContext context, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        /// <summary>
        /// Get all patients from the database.
        /// </summary>
        /// <returns>Patient's list.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll() 
        {
            return await _dbContext.Patients.ToListAsync();
        }

        /// <summary>
        /// Get a patient by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>Patient object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetById(int id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            if(patient == null) return NotFound();

            return patient;
        }

        /// <summary>
        /// Post a new patient to the database.
        /// </summary>
        /// <param name="dto">Patient's DTO</param>
        /// <returns>Proof that patient was created(REST).</returns>
        [HttpPost]
        public async Task<ActionResult<Patient>> Create(CreatePatientDTO dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            _dbContext.Patients.Add(patient);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, _mapper.Map<CreatePatientDTO>(patient));
        }

        /// <summary>
        /// Update an existing patient in the database.
        /// </summary>
        /// <param name="dto">Patient's DTO.</param>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(CreatePatientDTO dto,int id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            if(patient == null) return NotFound();

            _mapper.Map(dto,patient);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a patient by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var patient =  await _dbContext.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
