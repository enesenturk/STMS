using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Lectures.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Lectures.Accessors.Concrete.EntityFramework
{
    public class EfLectureDal : EfEntityRepositoryBase<t_lecture, ns_stmsContext>, ILectureDal
    {
    }
}
