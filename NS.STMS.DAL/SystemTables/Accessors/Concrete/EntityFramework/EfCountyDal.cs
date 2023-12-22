using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.SystemTables.Accessors.Concrete.EntityFramework
{
    public class EfCountyDal : EfEntityRepositoryBase<t_county, ns_stmsContext>, ICountyDal
    {
    }
}
