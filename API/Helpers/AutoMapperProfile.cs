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
            CreateMap<Message, MessageDto>()
            .ForMember(d => d.SenderPhotoUrl, o => o.MapFrom(s => s.Sender.Photos
                .FirstOrDefault(x => x.IsMain).Url))
            .ForMember(d => d.RecipientPhotoUrl, o => o.MapFrom(s => s.Recipient.Photos
                .FirstOrDefault(x => x.IsMain).Url));
            CreateMap<DateTime , DateTime>().ConvertUsing(d =>DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<DateTime? , DateTime?>().ConvertUsing(d => d.HasValue ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc): null);
        }
    }
}