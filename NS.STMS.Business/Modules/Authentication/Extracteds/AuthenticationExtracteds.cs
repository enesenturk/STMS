using NS.STMS.Business.Modules.SystemTables.EntityPropertySettings.Data.EntityProperties;
using NS.STMS.Core.Utilities.ExceptionHandling;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.DTO.Authentication.Response;
using NS.STMS.Entity.Context;

namespace NS.STMS.Business.Modules.Authentication.Extracteds
{
	public class AuthenticationExtracteds
	{

		#region CTOR

		private readonly IStudentDal _studentDal;
		private readonly IUserLoginHistoryDal _userLoginHistoryDal;

		public AuthenticationExtracteds(IStudentDal studentDal, IUserLoginHistoryDal userLoginHistoryDal)
		{
			_studentDal = studentDal;
			_userLoginHistoryDal = userLoginHistoryDal;
		}

		#endregion

		internal void AddLoginHistory(t_user loginUser, bool isSuccessful)
		{
			_userLoginHistoryDal.Add(new t_user_login_history
			{
				t_user_id = loginUser.id,
				is_successful = isSuccessful,
				description = "Login request."
			}, loginUser.id);
		}

		internal TryLoginResponseDto GetLoginResponseDto(t_user loginUser)
		{
			TryLoginResponseDto response = new TryLoginResponseDto
			{
				Id = loginUser.id,
				Email = loginUser.email,
				Name = loginUser.name,
				Surname = loginUser.surname,
				DateOfBirth = loginUser.date_of_birth,
				ImageBase64 = loginUser.image_base64,

				PreferredDateFormat = loginUser.preferred_date_format,
				PreferredLanguage = loginUser.preferred_language,
				PreferredNumberFormat = loginUser.preferred_number_format,

				AcceptedTerms = loginUser.accepted_terms,
				EmailVerified = loginUser.verified_email,
				NeedsChangePassword = loginUser.needs_change_password
			};

			if (loginUser.t_property_id_user_type == UserTypes.Student)
			{
				t_student student = _studentDal.Get(x => x.t_user_id == loginUser.id);

				if (student is null) throw new FatalException();

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

		internal bool IsUserBlocked(int userId)
		{
			List<t_user_login_history> logs = _userLoginHistoryDal.GetList(
				orderBy: x => x.created_at,
				filter: x => x.t_user_id == userId,
				orderByDesc: true,
				skipCount: 0,
				takeCount: 5);

			t_user_login_history lastSuccessfulLogin = logs.FirstOrDefault(x => x.is_successful);

			if (logs.Count == 5 && lastSuccessfulLogin is null)
				return true;

			return false;
		}
	}
}
