using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Lectures.Accessors.Concrete.EntityFramework
{
    public class EfGradeLectureDal : EfEntityRepositoryBase<t_grade_lecture, ns_stmsContext>, IGradeLectureDal
    {
    }
}
