using NS.STMS.Business.Modules.Authentication.Managers.Abstract;
using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings.Data.EntityProperties;
using NS.STMS.Core.Aspects.Postsharp;
using NS.STMS.Core.Helpers;
using NS.STMS.Core.Utilities.ExceptionHandling;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;
using NS.STMS.DTO.SystemTables.Address;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.Authentication.Managers.Concrete
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
				string hash = PasswordHasher.HashPasword(requestDto.password, out var salt);

				t_user user = _userDal.Add(new t_user
				{
					email = requestDto.email,
					password = hash,
					password_salt = salt,
					name = requestDto.name,
					surname = requestDto.surname,
					date_of_birth = DateOnly.FromDateTime(requestDto.dateOfBirth),
					t_county_id = requestDto.countyId,
					t_property_id_user_type = UserTypes.Student
				}, _id);

				_studentDal.Add(new t_student
				{
					t_user_id = user.id,
					t_grade_id = requestDto.gradeId,
					school_name = requestDto.schoolName,
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
			t_user loginUser = _userDal.GetWithProperties(x => x.email == requestDto.email, new string[] { "t_county" });

			if (loginUser is null) return null;

			bool verified = PasswordHasher.VerifyPassword(requestDto.password, loginUser.password, loginUser.password_salt);

			if (!verified) return null;

			LoginResponseDto response = new LoginResponseDto
			{
				email = loginUser.email,
				name = loginUser.name,
				surname = loginUser.surname,
				dateOfBirth = loginUser.date_of_birth,
				imageBase64 = loginUser.image_base64,
				address = new AddressDto
				{
					countyId = loginUser.t_county_id,
					cityId = loginUser.t_county.t_city_id
				}
			};

			if (loginUser.t_property_id_user_type == UserTypes.Student)
			{
				t_student student = _studentDal.Get(x => x.t_user_id == loginUser.id);

				if (student is null) throw new CoreException("Please contact to the system admin.");

				response.isStudent = true;
				response.student = new StudentLoginResponseDto
				{
					gradeId = student.t_grade_id,
					schoolName = student.school_name
				};
			}
			else if (loginUser.t_property_id_user_type == UserTypes.Teacher)
			{
				throw new NotImplementedException();
			}
			else
			{
				throw new NotImplementedException();
			}

			return response;
		}

		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion

	}
}
