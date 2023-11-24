using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_lecture : IEntity
{
	public int t_grade_id { get; set; }

	public string name { get; set; }

	public virtual t_grade t_grade { get; set; }
}
