using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using System;
using System.Linq;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>().
            ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photo.FirstOrDefault(p => p.IsMain ?? false).Url);
            }).
            ForMember(dest => dest.Age, opt =>
            {
                opt.ResolveUsing(d => (d.DateOfBirth ?? DateTime.Now).CalculateAge());
            });

            CreateMap<User, UserForDetailedDto>().
            ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photo.FirstOrDefault(p => p.IsMain ?? false).Url);
            });
            CreateMap<Photo, PhotosForDetailedDto>();

        }
    }
}