using NS.STMS.Business.Authentication.Managers.Abstract;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Authentication.Managers.Concrete
{
	public class UserManager : IUserManager
	{

		#region CTOR

		private readonly IUserDal _userDal;
		private readonly IStudentDal _studentDal;

		public UserManager(
			IUserDal userDal,
			IStudentDal studentDal
			)
		{
			_userDal = userDal;
			_studentDal = studentDal;
		}

		#endregion

		#region Create

		public void CreateStudent(CreateStudentRequestDto requestDto)
		{
			t_user user = new t_user
			{
				email = requestDto.Email,
				name = requestDto.Name,
				date_of_birth = DateOnly.FromDateTime(requestDto.DateOfBirth),
				surname = requestDto.Surname,
				t_county_id = requestDto.CountyId,

			};

		}

		#endregion

		#region Read

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
