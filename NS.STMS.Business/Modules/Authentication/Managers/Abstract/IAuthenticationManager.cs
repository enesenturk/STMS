using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;

namespace NS.STMS.Business.Modules.Authentication.Managers.Abstract
{
    public interface IAuthenticationManager
    {

		#region Create

		void CreateStudent(CreateStudentRequestDto requestDto);

		#endregion

		#region Read

		TryLoginResponseDto Login(LoginRequestDto requestDto);

		#endregion

		#region Update

		void AcceptTermsAndConditions(AcceptTermsAndConditionsRequestDto requestDto);

		#endregion

		#region Delete

		#endregion

	}
}
