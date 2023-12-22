using NS.STMS.Business.Authentication.Managers.Abstract;
using NS.STMS.Core.Aspects.Postsharp;
using NS.STMS.Core.Helpers;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Authentication.Managers.Concrete
{
	public class AuthenticationManager : IAuthenticationManager
	{

		#region CTOR

		private int _id = 1;
		private readonly IUserDal _userDal;
		private readonly IStudentDal _studentDal;

		public AuthenticationManager(
			IUserDal userDal,
			IStudentDal studentDal
			)
		{
			_userDal = userDal;
			_studentDal = studentDal;
		}

		#endregion

		#region Create

		[TransactionalOperationAspect]
		public void CreateStudent(CreateStudentRequestDto requestDto)
		{
			try
			{
				string hash = PasswordHasher.HashPasword(requestDto.Password, out var salt);

				t_user user = _userDal.Add(new t_user
				{
					email = requestDto.Email,
					password = hash,
					password_salt = salt,
					name = requestDto.Name,
					surname = requestDto.Surname,
					date_of_birth = DateOnly.FromDateTime(requestDto.DateOfBirth),
					t_county_id = requestDto.CountyId
				}, _id);

				_studentDal.Add(new t_student
				{
					t_user_id = user.id,
					t_grade_id = requestDto.GradeId,
					school_name = requestDto.SchoolName,
				}, _id);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		#endregion

		#region Read

		public LoginResponseDto Login(LoginRequestDto requestDto)
		{
			string hash = PasswordHasher.HashPasword(requestDto.Password, out var salt);

			t_user loginUser = _userDal.Get(x => x.email == requestDto.EMail && x.password == hash && x.password_salt == salt);

			if (loginUser == null) return null;

			//loginUser.t_property_id_user_type

			throw new Exception();
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
