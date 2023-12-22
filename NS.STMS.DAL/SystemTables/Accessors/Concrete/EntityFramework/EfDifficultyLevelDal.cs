using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.SystemTables.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.SystemTables.Accessors.Concrete.EntityFramework
{
    public class EfDifficultyLevelDal : EfEntityRepositoryBase<t_difficulty_level, ns_stmsContext>, IDifficultyLevelDal
    {
    }
}
