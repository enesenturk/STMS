using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_student : IEntity
{

	public int t_user_id { get; set; }

	public int t_grade_id { get; set; }

	public string school_name { get; set; }

	public virtual t_grade t_grade { get; set; }

	public virtual t_user t_user { get; set; }
}
