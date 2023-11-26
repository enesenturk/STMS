using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Abstract.Lectures;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Concrete.EntityFramework.Lecture
{
	public class EfGradeLectureDal : EfEntityRepositoryBase<t_grade_lecture, ns_stmsContext>, IGradeLectureDal
	{
	}
}
