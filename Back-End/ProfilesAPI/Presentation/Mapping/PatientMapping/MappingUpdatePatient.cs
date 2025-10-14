using Application.DTO.Doctors;
using Application.DTO.Patients;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.PatientMapping
{
    public class MappingUpdatePatient : Profile
    {
        public MappingUpdatePatient()
        {
            CreateMap<UpdatePatientDTO, Patient>();

            CreateMap<Patient, UpdatePatientDTO>();
        }
    }
}
