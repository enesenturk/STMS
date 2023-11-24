using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_grade : IEntity
{
	public string name { get; set; }

	public virtual ICollection<t_lecture> t_lectures { get; set; } = new List<t_lecture>();
}
