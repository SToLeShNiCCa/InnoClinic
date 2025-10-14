using Application.DTO.Patients;
using AutoMapper;
using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Presentation.Mapping.PatientMapping
{
    /// <summary>
    /// AutoMapper profile for mapping between Patients and DTOPatients.
    /// </summary>
    public class MappingCreatePatient : Profile
    {
        public MappingCreatePatient()
        {
            // Mapping configuration between Patients and DTOPatients
            CreateMap<CreatePatientDTO, Patient>();
            // Reverse mapping
            CreateMap<Patient, CreatePatientDTO>();
        }
    }
}
