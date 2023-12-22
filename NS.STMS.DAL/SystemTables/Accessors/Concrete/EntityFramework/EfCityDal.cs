using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.SystemTables.Accessors.Concrete.EntityFramework
{
    public class EfCityDal : EfEntityRepositoryBase<t_city, ns_stmsContext>, ICityDal
    {
    }
}
