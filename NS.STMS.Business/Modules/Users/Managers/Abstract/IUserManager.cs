using NS.STMS.DTO.Users;
using NS.STMS.DTO.Users.Request;

namespace NS.STMS.Business.Modules.Users.Managers.Abstract
{
	public interface IUserManager
	{

		#region Create

		void CreateUser(CreateUserRequestDto requestDto);

		#endregion

		#region Read

		List<UserDto> GetUsers();

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
