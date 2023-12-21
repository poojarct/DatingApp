using AutoMapper;
using API.DTOs;
using API.Entities;
using API.Extensions;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<APPUser, MemberDto>()
            .ForMember(dest =>dest.PhotoUrl, opt => opt.MapFrom(src =>src.Photos.FirstOrDefault(x =>x.IsMain).Url))
            .ForMember(dest =>dest.Age, opt => opt.MapFrom(src =>src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, APPUser>();
            CreateMap<RegisterDto, APPUser>();
        }
    }
}