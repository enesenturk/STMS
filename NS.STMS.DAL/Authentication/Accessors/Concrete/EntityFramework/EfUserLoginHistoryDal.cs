using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Authentication.Accessors.Concrete.EntityFramework
{
	public class EfUserLoginHistoryDal : EfEntityRepositoryBase<t_user_login_history, ns_stmsContext>, IUserLoginHistoryDal
	{
	}
}
