using Application.DTO.Doctors;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.DoctorMapping
{
    public class MappingReadDoctor : Profile
    {
        public MappingReadDoctor()
        {
            CreateMap<ReadDoctorDTO, Doctor>();
            CreateMap<Doctor, ReadDoctorDTO>();
        }
    }
}
