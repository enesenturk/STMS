using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Abstract.SystemTable;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Concrete.EntityFramework.SystemTable
{
	public class EfDifficultyLevelDal : EfEntityRepositoryBase<t_difficulty_level, ns_stmsContext>, IDifficultyLevelDal
	{
	}
}
