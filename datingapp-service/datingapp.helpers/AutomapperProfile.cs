using AutoMapper;
using datingapp_service.datingapp.dtos;
using datingapp_service.datingapp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserListDTO>().
                ForMember(d => d.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.is_main_photo).photo_url)).
                ForMember(d => d.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserDetailsDTO>().ForMember(d => d.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.is_main_photo).photo_url)).
                ForMember(d => d.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDetailsDTO>();
        }
    }
}
