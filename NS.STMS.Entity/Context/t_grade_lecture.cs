using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_grade_lecture : IEntity
{
	public int t_grade_id { get; set; }

	public int t_lecture_id { get; set; }

	public virtual t_grade t_grade { get; set; }

	public virtual t_lecture t_lecture { get; set; }
}
