using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_country : IEntity
{

	public string name { get; set; }

	public virtual ICollection<t_city> t_cities { get; set; } = new List<t_city>();
}
