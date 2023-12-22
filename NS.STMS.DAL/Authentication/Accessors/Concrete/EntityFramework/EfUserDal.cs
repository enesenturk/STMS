using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Authentication.Accessors.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<t_user, ns_stmsContext>, IUserDal
    {
    }
}
