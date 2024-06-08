using NS.STMS.Core.Helpers;
using NS.STMS.Core.Utilities.ExceptionHandling;
using NS.STMS.Entity.Context;
using NS.STMS.Resources.Language.Languages;

namespace NS.STMS.Business.Modules.Authentication.Rules
{
	public class AuthenticationRules
	{

		#region CTOR

		public AuthenticationRules()
		{

		}

		#endregion

		public void ForgotPasswordTokenCanNotBeUsedOrExpired(t_user_forgot_password forgotPassword)
		{
			if (forgotPassword is null)
				throw new BusinessException(Messages.Request_Not_Found_Please_Repeat);

			if (forgotPassword.updated_at is not null)
				throw new BusinessException(Messages.Request_Is_Used);

			DateTime expiresAt = DateTimeHelper.GetNow().AddMinutes(-5);

			if (expiresAt > forgotPassword.created_at)
				throw new BusinessException(Messages.Request_Expired);
		}

	}
}
