using AutoMapper;
using NS.STMS.Core.Extentions;
using NS.STMS.DTO;
using NS.STMS.DTO.SystemTables.DifficultyLevel;
using NS.STMS.DTO.SystemTables.Language;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.SystemTables.Mappings
{
	public class SystemTableProfile : Profile
	{
		public SystemTableProfile()
		{

			CreateMap<t_city, JSonDto>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.name));

			CreateMap<t_county, JSonDto>()
				.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.name));

			CreateMap<t_difficulty_level, DifficultyLevelDto>().IgnoreAllVirtual();

			CreateMap<t_language, LanguageDto>()
				.ForMember(dest => dest.LanguageKey, opt => opt.MapFrom(src => src.language_key))
				.ForMember(dest => dest.trTR, opt => opt.MapFrom(src => src.tr_TR))
				.ForMember(dest => dest.enUS, opt => opt.MapFrom(src => src.en_US));

		}
	}
}
