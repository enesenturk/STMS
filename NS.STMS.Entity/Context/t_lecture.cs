using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_lecture : IEntity
{
	public string language_key { get; set; }

	public virtual t_country t_country { get; set; }

	public virtual ICollection<t_grade_lecture> t_grade_lectures { get; set; } = new List<t_grade_lecture>();
}
