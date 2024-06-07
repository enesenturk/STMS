using NS.STMS.Business.Modules.Authentication.Extracteds;
using NS.STMS.Business.Modules.Authentication.Managers.Abstract;
using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings.Data.EntityProperties;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.Core.Aspects.Postsharp;
using NS.STMS.Core.Helpers;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;
using NS.STMS.DTO.Users;
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

		private readonly AuthenticationExtracteds _authenticationExtracteds;

		private readonly IStudentDal _studentDal;
		private readonly IUserDal _userDal;

		private readonly IUserManager _userManager;

		public AuthenticationManager(
			AuthenticationExtracteds authenticationExtracteds,

			IStudentDal studentDal,
			IUserDal userDal,

			IUserManager userManager
			)
		{
			_authenticationExtracteds = authenticationExtracteds;

			_studentDal = studentDal;
			_userDal = userDal;

			_userManager = userManager;
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

		public TryLoginResponseDto Login(LoginRequestDto requestDto)
		{
			t_user loginUser = _userDal.Get(x => x.email == requestDto.Email);

			if (loginUser is null) return null;

			bool isUserBlocked = _authenticationExtracteds.IsUserBlocked(loginUser.id);

			if (isUserBlocked) return new TryLoginResponseDto { IsBlocked = true };

			bool correctPassword = PasswordHasher.VerifyPassword(requestDto.Password, loginUser.password, loginUser.password_salt);

			if (!correctPassword)
			{
				_authenticationExtracteds.AddLoginHistory(loginUser, isSuccessful: false);

				return null;
			}

			TryLoginResponseDto response = _authenticationExtracteds.GetLoginResponseDto(loginUser);

			_authenticationExtracteds.AddLoginHistory(loginUser, isSuccessful: true);

			return response;
		}

		#endregion

		#region Update

		[TransactionalOperationAspect]
		public void AcceptTermsAndConditions(AcceptTermsAndConditionsRequestDto requestDto)
		{
			t_user user = _userDal.Get(x => x.email == requestDto.Email);

			user.accepted_terms = true;
			user.accepted_terms_at = DateTimeHelper.GetNow();

			_userDal.Update(user, user.id);
			_userManager.CreateActivityLog(new UserActivityDto
			{
				UserId = user.id,
				Description = "Accepted terms and conditions."
			});
		}

		#endregion

		#region Delete

		#endregion

	}
}
