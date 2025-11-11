using Application.DTO;
using AutoMapper;
using Domain.Models;

namespace Presentation.Mapper
{
    public class PhotoMapper : Profile
    {
        public PhotoMapper()
        {
            CreateMap<Photo, PhotoDTO>();
            CreateMap<PhotoDTO, Photo>();
        }
    }
}
