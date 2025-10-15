using Application.DTO.Patients;
using Application.Services.Interfaces;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    /// <summary>
    /// PatientController class - API controller for managing patient entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Get all patients from the database.
        /// </summary>
        /// <returns>Patient's list.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll([FromQuery]PageInfo pageInfo,CancellationToken token) 
        {
            var doctors =  await _patientService.GetAllAsync(pageInfo,token);

            return doctors.ToActionResult();
        }

        /// <summary>
        /// Get a patient by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>Patient object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetById(int id, CancellationToken token)
        {
            var patient = await _patientService.GetByIdAsync(id, token);

            return patient.ToActionResult();
        }

        /// <summary>
        /// Post a new patient to the database.
        /// </summary>
        /// <param name="dto">Patient's DTO</param>
        /// <returns>Proof that patient was created(REST).</returns>
        [HttpPost]
        public async Task<ActionResult<Patient>> Create(CreatePatientDTO dto,CancellationToken token)
        {
            var newPatient = await _patientService.CreateAsync(dto,token);

            return newPatient.ToActionResult();
        }

        /// <summary>
        /// Update an existing patient in the database.
        /// </summary>
        /// <param name="dto">Patient's DTO.</param>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdatePatientDTO dto, CancellationToken token)
        {
            var updatedPatient = await _patientService.UpdateAsync(dto, token);

            return updatedPatient.ToActionResult();
        }

        /// <summary>
        /// Delete a patient by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken token)
        {
            await _patientService.DeleteAsync(id, token);
            return NoContent();
        }
    }
}
