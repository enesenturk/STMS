using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Lectures.Accessors.Concrete.EntityFramework
{
    public class EfGradeDal : EfEntityRepositoryBase<t_grade, ns_stmsContext>, IGradeDal
    {
    }
}
