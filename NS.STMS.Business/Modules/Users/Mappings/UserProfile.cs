using AutoMapper;
using NS.STMS.DTO.Users;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.Users.Mappings
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{

			CreateMap<t_user, UserDto>()
				.ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.t_property_id_user_typeNavigation.name));

		}
	}
}
