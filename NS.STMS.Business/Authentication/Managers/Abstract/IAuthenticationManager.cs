using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;

namespace NS.STMS.Business.Authentication.Managers.Abstract
{
	public interface IAuthenticationManager
	{

		#region Create

		void CreateStudent(CreateStudentRequestDto requestDto);

		#endregion

		#region Read

		LoginResponseDto Login(LoginRequestDto requestDto);

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
