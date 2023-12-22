using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Abstract.Authorization;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Concrete.EntityFramework.Authorization
{
	public class EfUserDal : EfEntityRepositoryBase<t_user, ns_stmsContext>, IUserDal
	{
	}
}
