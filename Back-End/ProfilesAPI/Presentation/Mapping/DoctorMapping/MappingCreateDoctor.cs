using Application.DTO.Doctors;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.DoctorMapping
{
    /// <summary>
    /// AutoMapper profile for mapping between Doctors and DTODoctors.
    /// </summary>
    public class MappingCreateDoctor : Profile
    {
        public MappingCreateDoctor() 
        {
            //AutoMapper configuration for Doctors and DTODoctors
            CreateMap<CreateDoctorDTO, Doctor>();
            // Reverse mapping
            CreateMap<Doctor, CreateDoctorDTO>();
        }
    }
}
