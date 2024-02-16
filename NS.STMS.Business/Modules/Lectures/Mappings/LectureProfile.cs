using AutoMapper;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.Lectures.Mappings
{
    public class LectureProfile : Profile
    {
        public LectureProfile()
        {

            CreateMap<t_lecture, JSonDto>()
                .ForMember(dest => dest.key, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.name));

        }
    }
}
