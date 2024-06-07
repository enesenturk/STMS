using AutoMapper;
using NS.STMS.DTO.Authentication.Response;

namespace NS.STMS.Business.Modules.Authentication.Mappings
{
	public class AuthenticationProfile : Profile
	{
		public AuthenticationProfile()
		{

			CreateMap<TryLoginResponseDto, LoginResponseDto>();

		}
	}
}
