using NS.STMS.Business.Modules.Authentication.Extracteds;
using NS.STMS.Business.Modules.Authentication.Managers.Abstract;
using NS.STMS.Business.Modules.Authentication.Rules;
using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings.Data.EntityProperties;
using NS.STMS.Business.Modules.Users.Managers.Abstract;
using NS.STMS.Business.ServiceAdapters.Adapters.Abstract;
using NS.STMS.Business.ServiceAdapters.Models.EmailService;
using NS.STMS.Business.Templates;
using NS.STMS.Core.Aspects.Postsharp;
using NS.STMS.Core.Helpers;
using NS.STMS.Core.Utilities.ExceptionHandling;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Authentication.Request;
using NS.STMS.DTO.Authentication.Response;
using NS.STMS.DTO.Users;
using NS.STMS.Entity.Context;
using NS.STMS.Resources.Language.Languages;
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
		private readonly AuthenticationRules _authenticationRules;

		private readonly IStudentDal _studentDal;
		private readonly IUserDal _userDal;
		private readonly IUserForgotPassword _userForgotPassword;

		private readonly IUserManager _userManager;

		private readonly IEmailServiceAdapter _emailServiceAdapter;

		public AuthenticationManager(
			AuthenticationExtracteds authenticationExtracteds,
			AuthenticationRules authenticationRules,

			IStudentDal studentDal,
			IUserDal userDal,
			IUserForgotPassword userForgotPassword,

			IUserManager userManager,

			IEmailServiceAdapter emailServiceAdapter
			)
		{
			_authenticationExtracteds = authenticationExtracteds;
			_authenticationRules = authenticationRules;

			_studentDal = studentDal;
			_userDal = userDal;
			_userForgotPassword = userForgotPassword;

			_userManager = userManager;

			_emailServiceAdapter = emailServiceAdapter;
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
				Description = $"Accepted terms and conditions."
			});
		}

		[TransactionalOperationAspect]
		public void ForgotPassword(ForgotPasswordRequestDto requestDto)
		{
			t_user user = _userDal.Get(x => x.email == requestDto.Email && x.verified_email);

			if (user is null)
				throw new BusinessException(Messages.Email_Is_Not_Verified);

			Guid guid = Guid.NewGuid();

			string email = EmailTemplate.GetForgotPasswordEmailHTML(guid);

			_emailServiceAdapter.SendEmail(new SendEmailModel
			{
				ReceiverEmailAddress = user.email,
				Subject = $"STMS {Messages.Forgot_Password}",
				EmailBody = email
			});

			_userForgotPassword.Add(new t_user_forgot_password
			{
				guid = guid
			}, user.id);

			_userManager.CreateActivityLog(new UserActivityDto
			{
				UserId = user.id,
				Description = $"Forgot password request. guid: {guid}"
			});
		}

		[TransactionalOperationAspect]
		public void ResetPassword(ResetPasswordRequestDto requestDto)
		{
			t_user_forgot_password forgotPassword = _userForgotPassword.GetLast(
				filter: x => x.guid == requestDto.Token,
				orderBy: x => x.created_at,
				orderByDesc: true);

			_authenticationRules.ForgotPasswordTokenCanNotBeUsedOrExpired(forgotPassword);

			string passwordDecrypted = EncryptionHelper.Decrypt(requestDto.Password, AppSettings.EncryptionKey);
			string hash = PasswordHasher.HashPasword(passwordDecrypted, out var salt);

			t_user user = _userDal.Get(x => x.id == forgotPassword.created_by);

			user.password = hash;
			user.password_salt = salt;

			_userDal.Update(user, user.id);

			_userForgotPassword.Update(forgotPassword, user.id);

			_userManager.CreateActivityLog(new UserActivityDto
			{
				UserId = user.id,
				Description = $"Reset password completed."
			});
		}

		#endregion

		#region Delete

		#endregion

	}
}
