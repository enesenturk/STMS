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
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.name));

        }
    }
}
