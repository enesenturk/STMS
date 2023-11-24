using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Abstract.SystemTable;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Concrete.EntityFramework.SystemTable
{
	public class EfCityDal : EfEntityRepositoryBase<t_city, ns_stmsContext>, ICityDal
	{
	}
}
