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
using NS.STMS.Resources.Security.Encryption;
using NS.STMS.Settings;

namespace NS.STMS.Business.Modules.Authentication.Managers.Concrete
{
	public class AuthenticationManager : IAuthenticationManager
	{

		#region CTOR

		// TODO:
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
			string passwordDecrypted = EncryptionHelper.Decrypt(requestDto.Password, AppSettings.EncryptionKey);

			string hash = PasswordHasher.HashPasword(passwordDecrypted, out var salt);

			t_user user = _userDal.Add(new t_user
			{
				email = requestDto.Email,
				password = hash,
				password_salt = salt,
				name = requestDto.Name,
				surname = requestDto.Surname,
				date_of_birth = DateOnly.FromDateTime(requestDto.DateOfBirth),
				t_county_id = requestDto.CountyId,
				t_property_id_user_type = UserTypes.Student
			}, _id);

			_studentDal.Add(new t_student
			{
				t_user_id = user.id,
				t_grade_id = requestDto.GradeId,
				school_name = requestDto.SchoolName,
			}, _id);
		}

		#endregion

		#region Read

		public LoginResponseDto Login(LoginRequestDto requestDto)
		{
			t_user loginUser = _userDal.GetWithProperties(x => x.email == requestDto.Email, new string[] { "t_county" });

			if (loginUser is null) return null;

			bool verified = PasswordHasher.VerifyPassword(requestDto.Password, loginUser.password, loginUser.password_salt);

			if (!verified) return null;

			LoginResponseDto response = new LoginResponseDto
			{
				Email = loginUser.email,
				Name = loginUser.name,
				Surname = loginUser.surname,
				DateOfBirth = loginUser.date_of_birth,
				ImageBase64 = loginUser.image_base64,
				Address = new AddressDto
				{
					CountyId = loginUser.t_county_id,
					CityId = loginUser.t_county.t_city_id
				}
			};

			if (loginUser.t_property_id_user_type == UserTypes.Student)
			{
				t_student student = _studentDal.Get(x => x.t_user_id == loginUser.id);

				if (student is null) throw new FatalException();

				response.IsStudent = true;
				response.Student = new StudentLoginResponseDto
				{
					GradeId = student.t_grade_id,
					SchoolName = student.school_name
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
