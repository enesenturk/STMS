using AutoMapper;
using NS.STMS.DTO;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.Lectures.Mappings
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {

            CreateMap<t_grade, JSonDto>()
                .ForMember(dest => dest.key, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.name));

        }
    }
}
