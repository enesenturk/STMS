using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.SystemTables.Accessors.Concrete.EntityFramework
{
	public class EfPropertyDal : EfEntityRepositoryBase<t_property, ns_stmsContext>, IPropertyDal
	{
	}
}
