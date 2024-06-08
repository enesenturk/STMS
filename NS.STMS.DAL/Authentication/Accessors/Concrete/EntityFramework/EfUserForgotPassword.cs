using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Authentication.Accessors.Concrete.EntityFramework
{
	public class EfUserForgotPassword : EfEntityRepositoryBase<t_user_forgot_password, ns_stmsContext>, IUserForgotPassword
	{
	}
}
