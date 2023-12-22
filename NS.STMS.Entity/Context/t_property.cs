using NS.STMS.Core.DataAccess;

namespace NS.STMS.Entity.Context;

public partial class t_property : IEntity
{

	public string name { get; set; }

	public int t_property_type_id { get; set; }

	public virtual ICollection<t_user> t_users { get; set; } = new List<t_user>();
}
