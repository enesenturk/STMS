using AutoMapper;
using NS.STMS.Core.Extentions;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.SystemTables.Mappings
{
	public class SystemTableProfile : Profile
	{
		public SystemTableProfile()
		{

			CreateMap<t_difficulty_level, DifficultyLevelResponseDto>().IgnoreAllVirtual();

			CreateMap<t_city, JSonDto>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.name));

			CreateMap<t_county, JSonDto>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.name));

		}
	}
}
