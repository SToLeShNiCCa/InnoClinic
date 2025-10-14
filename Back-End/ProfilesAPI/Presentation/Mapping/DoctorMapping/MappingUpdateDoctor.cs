using Application.DTO.Doctors;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.DoctorMapping
{
    public class MappingUpdateDoctor : Profile
    {
        public MappingUpdateDoctor()
        {
            CreateMap<UpdateDoctorDTO, Doctor>();
            CreateMap<Doctor, UpdateDoctorDTO>();
        }
    }
}
