using NS.STMS.Core.DataAccess.EntityFramework;
using NS.STMS.DAL.Authentication.Accessors.Abstract;
using NS.STMS.Entity.Context;

namespace NS.STMS.DAL.Authentication.Accessors.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<t_student, ns_stmsContext>, IStudentDal
    {
    }
}
