using Application.DTO.Patients;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.PatientMapping
{
    public class MapingReadPatient : Profile
    {
        public MapingReadPatient()
        {
            CreateMap<ReadPatientDTO, Patient>();
            CreateMap<Patient, ReadPatientDTO>();
        }
    }
}
