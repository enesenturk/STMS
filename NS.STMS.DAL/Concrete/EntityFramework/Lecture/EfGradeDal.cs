using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Abstract.Lectures;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Concrete.EntityFramework.Lecture
{
	public class EfGradeDal : EfEntityRepositoryBase<t_grade, ns_stmsContext>, IGradeDal
	{
	}
}
